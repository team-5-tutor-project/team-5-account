using System.Threading.Tasks;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Users
{
    public interface IUserService
    {
        Task<User> Authenticate(string login, string password);
    }
}