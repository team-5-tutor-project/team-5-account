using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.TutorController.Data;

namespace TutorProject.Account.BLL.Tutors.Services
{
    public class TutorService : ITutorService
    {
        private List<Tutor> _tutors;
        public async Task<Guid> SignUp(TutorSignUpData tutorDta)
        {
            var tutor = new Tutor()
            {
                Id = Guid.NewGuid(),
                Login = tutorDta.Login,
                Name = tutorDta.Name,
                Password = tutorDta.Password
            };
            //заглушка
            return tutor.Id;
        }

        public async Task<Guid> SignIn(TutorSignInData tutorData)
        {
            //заглушка
            return Guid.NewGuid();
        }
    }
}