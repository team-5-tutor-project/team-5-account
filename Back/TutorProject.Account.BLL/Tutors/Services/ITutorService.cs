using System;
using System.Threading.Tasks;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Tutors.Services
{
    public interface ITutorService
    {
        Task<Tutor> SignUp(TutorSignUpData tutorData);
        Task ChangeDescription(Guid tutorId, ChangeDescriptionData data);
    }
}