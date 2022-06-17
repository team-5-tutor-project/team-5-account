using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Users
{
    public class UserService : IUserService
    {
        private readonly TutorContext _context;

        public UserService(TutorContext context)
        {
            _context = context;
        }

        public Task<User> Authenticate(string login, string password)
        {
            return _context.Users.SingleOrDefaultAsync(user => user.Login == login && user.Password == password);
        }
    }
}