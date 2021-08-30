using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace PD4_PZ_109602_202108.Models
{
    public class ChatMessage
    {
        public int ID { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public virtual AppUser Sender { get; set; }
    }
}
