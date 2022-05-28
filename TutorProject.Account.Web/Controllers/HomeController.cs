using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.Web.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly TutorContext _tutorContext;
        
        public HomeController(TutorContext tutorContext)
        {
            _tutorContext = tutorContext;
        }
        
        [HttpGet("/hello")]
        public string Hello()
        {
            return "Hello World!";
        }
        
        [HttpGet("/{id}/chats")]
        public async Task<ActionResult<List<Chat>>> GetChats(Guid id)
        {
            User user = _tutorContext.Clients.FirstOrDefault(x => x.Id == id);
            if (user == null)
                user = _tutorContext.Tutors.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var chats = await _tutorContext.Chats.Where(x => x.Tutor == user || x.Client == user).ToListAsync();

            if (chats == null)
            {
                return NotFound();
            }

            return chats.ToList();
        }

        [HttpGet("/{id}/chats/{chatID}")]
        public async Task<ActionResult<Chat>> GetChatByID(Guid id, Guid chatID)
        {
            
            User user = await _tutorContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                user = await _tutorContext.Tutors.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            Chat chat = await _tutorContext.Chats.FirstOrDefaultAsync(x =>
                (x.Tutor == user  || x.Client == user) && x.ChatId == chatID);
            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }
    }
}