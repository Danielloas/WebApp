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
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public DetailsModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Manager Manager { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mangers == null)
            {
                return NotFound();
            }

            var manager = await _context.Mangers.FirstOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }
            else 
            {
                Manager = manager;
            }
            return Page();
        }
    }
}
