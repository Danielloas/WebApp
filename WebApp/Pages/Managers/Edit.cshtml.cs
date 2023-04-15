using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.Identity;
using WebApp.Models;

namespace WebApp.Pages.Managers
{
    public class EditModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly WebApp.Data.ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context, IMapper mapper)
        {
                _mapper = mapper;
                _context = context;
        }

        [BindProperty]
        public ManagerModel Manager { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mangers == null)
            {
                return NotFound();
            }

            var manager =  await _context.Mangers.FirstOrDefaultAsync(m => m.Id == id);

            Manager = _mapper.Map<Manager, ManagerModel>(manager);

            if (manager == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(Manager.Deleted)
            {
                ModelState.AddModelError("Manager.Deleted", "Clould not be deleted");
                return Page();
            }

            var manager = _mapper.Map<Manager>(Manager);

            _context.Attach(Manager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(Manager.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ManagerExists(int id)
        {
          return (_context.Mangers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
