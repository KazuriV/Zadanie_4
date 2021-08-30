using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace PD4_PZ_109602_202108.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class MessageHubModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public MessageHubModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<MessageHubModel> _logger;

        public MessageHubModel(ILogger<MessageHubModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet()
        {
            await _context.ChatMessages
              .Include(c => c.Sender).ToListAsync();
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
