using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.BLL.Tutors.Dto;
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
            var isExists = _context.Tutors.AnyAsync(tutor => tutor.Login == tutorData.Login);

            if (isExists.Result)
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
            
            _context.Tutors.AddAsync(tutor);
            _context.SaveChangesAsync();
            
            var tutorLogIn = _mapper.Map<TutorLogInDto>(tutor);
            
            return tutorLogIn;
        }

        public async Task<TutorLogInDto> SignIn(TutorSignInData tutorData)
        {
            var isExists = _context.Tutors.AnyAsync(tutor => tutor.Login == tutorData.Login && 
                                                             tutor.Password == tutorData.Password);
            if (!isExists.Result)
            {
                return null;
            }

            var tutor = _context.Tutors.FindAsync(tutorData.Login);
                
            var tutorLogIn = _mapper.Map<TutorLogInDto>(tutor);    
                
            return tutorLogIn;
        }
    }
}