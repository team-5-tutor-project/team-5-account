using System;
using System.Threading.Tasks;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.BLL.Tutors.Dto;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.TutorController.Data;

namespace TutorProject.Account.BLL.Tutors.Services
{
    public interface ITutorService
    {
        Task<TutorLogInDto> SignUp(TutorSignUpData tutorData);
        Task<TutorLogInDto> SignIn(TutorSignInData tutorData);
    }
}