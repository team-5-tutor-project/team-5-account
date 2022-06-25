using System.Threading.Tasks;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Subjects
{
    public interface ISubjectService
    {
        Task<Subject> GetOrAdd(string name);
    }
}