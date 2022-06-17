using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly TutorContext _tutorContext;

        public AuthorizationService(TutorContext tutorContext)
        {
            _tutorContext = tutorContext;
        }
        
        public async Task<AuthorizationToken> Authorize(User user)
        {
            var activeToken = await GetActiveToken(user);
            if (activeToken is not null)
                return activeToken;
            
            var token = new AuthorizationToken
            {
                Owner = user
            };
            await _tutorContext.AuthorizationTokens.AddAsync(token);
            await _tutorContext.SaveChangesAsync();
            return token;
        }

        public async Task CancelAuthorization(User user)
        {
            var token = await GetActiveToken(user);
            if (token is null)
                return;
            
            token.Canceled = true;
            _tutorContext.AuthorizationTokens.Update(token);
            await _tutorContext.SaveChangesAsync();
        }

        private Task<AuthorizationToken> GetActiveToken(User user)
        {
            return _tutorContext.AuthorizationTokens
                .Where(token => token.Owner == user && token.Active)
                .SingleOrDefaultAsync();
        }

        public async Task<User> GetUserByToken(string tokenString)
        {
            var token = await _tutorContext.AuthorizationTokens
                .SingleOrDefaultAsync(x => x.Token == tokenString);

            if (token is null || !token.Active)
                return null;

            return token.Owner;
        }
    }
}