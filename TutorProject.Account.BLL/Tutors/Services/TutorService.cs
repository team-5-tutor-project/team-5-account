using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly Mapper _mapper;

        public async Task<TutorLogInDto> SignUp(TutorSignUpData tutorData)
        {
            var isExists = await _context.Tutors.AnyAsync(tutor => tutor.Login == tutorData.Login);

            if (isExists)
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
            
            var tutorLogIn = _mapper.Map<TutorLogInDto>(tutor);
            
            return tutorLogIn;
        }

        public async Task<TutorLogInDto> SignIn(TutorSignInData tutorData)
        {
            var isExists = await _context.Tutors.AnyAsync(tutor => tutor.Login == tutorData.Login && 
                                                                   tutor.Password == tutorData.Password);
            if (!isExists)
            {
                return null;
            }

            var tutor = await _context.Tutors.FindAsync(tutorData.Login);
                
            var tutorLogIn = _mapper.Map<TutorLogInDto>(tutor);    
                
            return tutorLogIn;
        }
    }
}