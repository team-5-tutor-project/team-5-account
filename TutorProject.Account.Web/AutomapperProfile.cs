﻿using AutoMapper;
using TutorProject.Account.BLL.Clients.Data;
using TutorProject.Account.BLL.Clients.Result;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.BLL.Tutors.Result;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.ClientController.Data;
using TutorProject.Account.Web.Controllers.ClientController.Dto;
using TutorProject.Account.Web.Controllers.TutorController.Data;
using TutorProject.Account.Web.Controllers.TutorController.Dto;

namespace TutorProject.Account.Web
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //CreateMap<Source, Result>();
            CreateMap<ClientSignUpDto, ClientSignUpData>();
            CreateMap<ClientSignInDto, ClientSignInData>();
            CreateMap<Client, ClientLogInDto>();
            CreateMap<Tutor, TutorLogInDto>();
            CreateMap<TutorSignUpDto, TutorSignUpData>();
            CreateMap<TutorSignInDto, TutorSignInData>();
            
        }
    }
}