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
        Task<Tutor> SignUp(TutorSignUpData tutorData);
        Task<Tutor> SignIn(TutorSignInData tutorData);
        Task ChangeDescription(Guid tutorId, ChangeDescriptionData data);
    }
}