﻿using System;

namespace TutorProject.Account.Web.Controllers.Dto.Tutor
{
    public class TutorSignInDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }
    }
}