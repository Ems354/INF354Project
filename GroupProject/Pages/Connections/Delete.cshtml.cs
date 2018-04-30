using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupProject.Data;
using GroupProject.Entity;

namespace GroupProject.Pages.Connections
{
    public class DeleteModel : PageModel
    {
        private readonly GroupProject.Data.ISPContext _context;

        public DeleteModel(GroupProject.Data.ISPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Connection Connection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Connection = await _context.Connections.SingleOrDefaultAsync(m => m.ID == id);

            if (Connection == null)
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

            Connection = await _context.Connections.FindAsync(id);

            if (Connection != null)
            {
                _context.Connections.Remove(Connection);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
