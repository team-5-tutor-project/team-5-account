using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task CancelAuthorization(string authorizationToken)
        {
            var token = await _tutorContext.AuthorizationTokens
                .Where(x => x.Token == authorizationToken)
                .SingleOrDefaultAsync();
            
            if (token is null)
                return;
            
            token.Canceled = true;
            _tutorContext.AuthorizationTokens.Update(token);
            await _tutorContext.SaveChangesAsync();
        }

        public async Task<RightsCheckResult> CheckRights(string authorizationToken, params Guid[] availableUserId)
        {
            var user = await GetUserByToken(authorizationToken);

            if (user is null)
                return new RightsCheckResult
                {
                    IsSuccessful = false,
                    ErrorMessage = "Для выполнения операции необходима авторизация"
                };
            
            if (availableUserId.Length != 0 && !availableUserId.Contains(user.Id))
                return new RightsCheckResult
                {
                    IsSuccessful = false,
                    ErrorMessage = "Отказано в доступе"
                };

            return new RightsCheckResult
            {
                IsSuccessful = true,
                AuthorizedUser = user
            };
        }

        private async Task<AuthorizationToken> GetActiveToken(User user)
        {
            var tokens = await _tutorContext.AuthorizationTokens
                .Where(token => token.Owner == user && !token.Canceled)
                .ToListAsync();

            var token = tokens
                .SingleOrDefault(token => token.ExpireAt.CompareTo(DateTime.Now) > 0);
            
            return token;
        }

        public async Task<User> GetUserByToken(string tokenString)
        {

            var token = await _tutorContext.AuthorizationTokens
                .Include(x => x.Owner)
                .Where(token => token.Token == tokenString && !token.Canceled)
                .SingleOrDefaultAsync();
            
            

            if (token is null || token.ExpireAt.CompareTo(DateTime.Now) < 0)
                return null;

            return token.Owner;
        }
    }
}