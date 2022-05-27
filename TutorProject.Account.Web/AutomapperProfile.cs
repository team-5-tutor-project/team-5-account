using AutoMapper;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.Dto.Client;
using TutorProject.Account.Web.Controllers.Dto.Tutor;

namespace TutorProject.Account.Web
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //CreateMap<Source, Result>();
            CreateMap<ClientSignUpDto, Client>();
            CreateMap<TutorSignUpDto, Tutor>();
            CreateMap<ClientSignInDto, Client>();
            CreateMap<TutorSignInDto, Tutor>();
        }
    }
}