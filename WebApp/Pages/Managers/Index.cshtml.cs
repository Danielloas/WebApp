using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.Identity;

namespace WebApp.Pages.Managers
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public IndexModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Manager> Manager { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Mangers != null)
            {
                Manager = await _context.Mangers.ToListAsync();
            }
        }
    }
}
