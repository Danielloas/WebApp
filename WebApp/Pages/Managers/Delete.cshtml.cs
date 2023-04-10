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
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public DeleteModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Mangers == null)
            {
                return NotFound();
            }
            var manager = await _context.Mangers.FindAsync(id);

            if (manager != null)
            {
                Manager = manager;
                _context.Mangers.Remove(Manager);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
