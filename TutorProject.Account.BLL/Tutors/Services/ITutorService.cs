using System;
using System.Threading.Tasks;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.BLL.Tutors.Result;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.TutorController.Data;

namespace TutorProject.Account.BLL.Tutors.Services
{
    public interface ITutorService
    {
        Task<TutorLogInResult> SignUp(TutorSignUpData tutorData);
        Task<TutorLogInResult> SignIn(TutorSignInData tutorData);
    }
}