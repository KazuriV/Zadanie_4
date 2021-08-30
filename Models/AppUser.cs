using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PD4_PZ_109602_202108.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            ChatMessages = new HashSet<ChatMessage>();
        }
        // 1 - * AppUser || Message
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
