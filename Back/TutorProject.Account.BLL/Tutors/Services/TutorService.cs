using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TutorProject.Account.BLL.Subjects;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.BLL.Utils;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Tutors.Services
{
    public class TutorService : ITutorService
    {
        private readonly TutorContext _context;
        private readonly ISubjectService _subjectService;

        public TutorService(TutorContext context, ISubjectService subjectService)
        {
            _context = context;
            _subjectService = subjectService;
        }

        public async Task<Tutor> SignUp(TutorSignUpData tutorData)
        {
            var tutorWithSameLogin = await _context.Tutors.FirstOrDefaultAsync(tutor => tutor.Login == tutorData.Login);

            if (tutorWithSameLogin is not null)
            {
                return null;
            }
            
            var tutor = new Tutor
            {
                Id = Guid.NewGuid(),
                Login = tutorData.Login,
                Name = tutorData.Name,
                Password = tutorData.Password
            };

            var tutorToSubject = new TutorToSubject
            {
                Id = Guid.NewGuid(),
                Tutor = tutor,
                Subject = await _subjectService.GetOrAdd(tutorData.Subject)
            };
            
            var schedule = new Schedule()
            {
                Id = Guid.NewGuid(),
                Tutor = tutor,
                FreeTimeSchedule = new List<Day>(),
            };

            await _context.Schedules.AddAsync(schedule);
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