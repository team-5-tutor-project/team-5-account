using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.BLL.Utils;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

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

        public async Task ChangeDescription(Guid tutorId, ChangeDescriptionData data)
        {
            var tutor = await _context.Tutors.SingleOrDefaultAsync(tutor => tutor.Id == tutorId);

            if (tutor is null)
                throw new BusinessLogicException($"Отсутствует репетитор с заданным ID: {tutorId}");

            tutor.Description = data.Description;
            tutor.WorkFormat = data.WorkFormat ?? tutor.WorkFormat;
            tutor.PricePerHour = data.PricePerHour ?? tutor.PricePerHour;
            tutor.PupilMinClass = data.PupilMinClass ?? tutor.PupilMinClass;
            tutor.PupilMaxClass = data.PupilMaxClass ?? tutor.PupilMaxClass;

            _context.Update(tutor);
            await _context.SaveChangesAsync();
        }
    }
}