using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace TutorProject.Account.Common.Models
{
    public class AuthorizationToken
    {
        [Key]
        public string Token { get; private init; }
        
        public DateTime ExpireAt { get; private init; }
        
        public User Owner { get; set; }

        public bool Canceled { get; set; } = false;

        [NotMapped] 
        public bool Active => DateTime.Now < ExpireAt && !Canceled;

        public AuthorizationToken()
        {
            Token = GenerateToken();
            ExpireAt = DateTime.Now + TimeSpan.FromHours(1); 
        }

        private string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}