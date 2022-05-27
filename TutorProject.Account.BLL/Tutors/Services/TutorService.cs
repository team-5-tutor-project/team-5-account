using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Tutors.Services
{
    public class TutorService : ITutorService
    {
        private List<Tutor> _tutors;
        public async Task<Guid> SignUp(Tutor tutor)
        {
            //заглушка
            return tutor.Id;
        }

        public async Task<Guid> SignIn(Tutor tutor)
        {
            //заглушка
            return tutor.Id;
        }
    }
}