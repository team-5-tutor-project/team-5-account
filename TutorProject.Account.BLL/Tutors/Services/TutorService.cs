using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.BLL.Tutors.Result;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.TutorController.Data;

namespace TutorProject.Account.BLL.Tutors.Services
{
    public class TutorService : ITutorService
    {
        private readonly TutorContext _context;

        public TutorService(TutorContext context)
        {
            _context = context;
        }

        public async Task<Tutor> SignUp(TutorSignUpData tutorData)
        {
            var tutorWithSameLogin = await _context.Tutors.FirstOrDefaultAsync(tutor => tutor.Login == tutorData.Login);

            if (tutorWithSameLogin is not null)
            {
                return null;
            }
            
            var tutor = new Tutor()
            {
                Id = Guid.NewGuid(),
                Login = tutorData.Login,
                Name = tutorData.Name,
                Password = tutorData.Password
            };
            
            await _context.Tutors.AddAsync(tutor);
            await _context.SaveChangesAsync();

            return tutor;
        }

        public Task<Tutor> SignIn(TutorSignInData tutorData)
        {
            return _context.Tutors.SingleOrDefaultAsync(tutor => tutor.Login == tutorData.Login && 
                                                              tutor.Password == tutorData.Password);
        }
    }
}