using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD4_PZ_109602_202108.Data;
using PD4_PZ_109602_202108.Models;

namespace PD4_PZ_109602_202108.Pages
{
    public class HistoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public HistoryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ChatMessage> ChatMessage { get;set; }

        public async Task OnGetAsync()
        {
            ChatMessage = await _context.ChatMessages
                .Include(c => c.Sender).ToListAsync();
        }
    }
}
