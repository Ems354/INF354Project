using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupProject.Data;
using GroupProject.Entity;

namespace GroupProject.Pages.Titles
{
    public class EditModel : PageModel
    {
        private readonly GroupProject.Data.ISPContext _context;

        public EditModel(GroupProject.Data.ISPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Title Title { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Title = await _context.Titles.SingleOrDefaultAsync(m => m.ID == id);

            if (Title == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Title).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(Title.ID))
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

        private bool TitleExists(int id)
        {
            return _context.Titles.Any(e => e.ID == id);
        }
    }
}
