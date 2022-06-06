using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.Common
{
    public class TutorContext : DbContext
    {
        public TutorContext(DbContextOptions<TutorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TutorToSubject> TutorToSubjects { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Day> Days{ get; set; }
        
    }
}