using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PD4_PZ_109602_202108.Data;

namespace PD4_PZ_109602_202108.Pages
{
    public class UsersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UsersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<IdentityUser> Users { get; set; }
        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
