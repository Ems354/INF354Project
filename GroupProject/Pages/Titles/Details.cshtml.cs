using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupProject.Data;
using GroupProject.Entity;

namespace GroupProject.Pages.Titles
{
    public class DetailsModel : PageModel
    {
        private readonly GroupProject.Data.ISPContext _context;

        public DetailsModel(GroupProject.Data.ISPContext context)
        {
            _context = context;
        }

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
    }
}
