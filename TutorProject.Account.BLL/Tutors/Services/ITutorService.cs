using System;
using System.Threading.Tasks;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.TutorController.Data;

namespace TutorProject.Account.BLL.Tutors.Services
{
    public interface ITutorService
    {
        Task<Guid> SignUp(TutorSignUpData tutorData);
        Task<Guid> SignIn(TutorSignInData tutorData);
    }
}