using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly TutorContext _context;

        public SubjectService(TutorContext context)
        {
            _context = context;
        }

        public async Task<Subject> GetOrAdd(string name)
        {
            var subject = await _context.Subjects
                .Where(x => x.Name == name)
                .SingleOrDefaultAsync();

            if (subject is not null)
                return subject;

            subject = new Subject(name);
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return subject;
        }
    }
}