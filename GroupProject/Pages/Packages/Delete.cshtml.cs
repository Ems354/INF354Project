using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupProject.Data;
using GroupProject.Entity;

namespace GroupProject.Pages.Packages
{
    public class DeleteModel : PageModel
    {
        private readonly GroupProject.Data.ISPContext _context;

        public DeleteModel(GroupProject.Data.ISPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Package Package { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Package = await _context.Packages
                .Include(p => p.Connection).SingleOrDefaultAsync(m => m.ID == id);

            if (Package == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Package = await _context.Packages.FindAsync(id);

            if (Package != null)
            {
                _context.Packages.Remove(Package);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
