using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using PD4_PZ_109602_202108.Data;
using PD4_PZ_109602_202108.Models;

namespace PD4_PZ_109602_202108.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
        public readonly UserManager<AppUser> _userManager;

        public ChatHub(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public ChatMessage ChatMessage { get; set; }
        public async Task SendMessage(string message)
        {
            var chatMessage = new ChatMessage();
            chatMessage.User = Context.User.Identity.Name;
            chatMessage.Message = message;
            _context.Add(chatMessage);
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name ?? "anonymous", message);
        }
    }
}
