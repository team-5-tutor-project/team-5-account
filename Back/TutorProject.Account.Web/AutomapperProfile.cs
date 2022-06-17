using AutoMapper;
using TutorProject.Account.BLL.Chats.Data;
using TutorProject.Account.BLL.Clients.Data;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.ChatController.Dto;
using TutorProject.Account.Web.Controllers.ClientController.Dto;
using TutorProject.Account.Web.Controllers.TutorController.Dto;

namespace TutorProject.Account.Web
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ClientSignUpDto, ClientSignUpData>();
            CreateMap<TutorSignUpDto, TutorSignUpData>();
            CreateMap<ChangeDescriptionDto, ChangeDescriptionData>();
            CreateMap<CreateChatDTO, CreateChatData>();
            CreateMap<Chat, ChatDto>()
                .ForMember(dto => dto.TutorName, opt => opt.MapFrom(chat => chat.Tutor.Name))
                .ForMember(dto => dto.ClientName, opt => opt.MapFrom(chat => chat.Client.Name));
        }
    }
}