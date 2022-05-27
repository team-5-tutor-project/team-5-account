using System;
using System.Threading.Tasks;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Tutors.Services
{
    public interface ITutorService
    {
        Task<Guid> SignUp(Tutor tutor);
        Task<Guid> SignIn(Tutor tutor);
    }
}