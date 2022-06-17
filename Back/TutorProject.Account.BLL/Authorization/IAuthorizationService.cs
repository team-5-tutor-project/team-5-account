using System;
using System.Threading.Tasks;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Authorization
{
    public interface IAuthorizationService
    {
        Task<AuthorizationToken> Authorize(User user);

        Task CancelAuthorization(User user);

        Task<User> GetUserByToken(string tokenString);

        Task CancelAuthorization(string authorizationToken);

        Task<RightsCheckResult> CheckRights(string authorizationToken, params Guid[] availableUserId);
    }
}