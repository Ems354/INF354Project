using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroupProject.Data;
using GroupProject.Entity;

namespace GroupProject.Pages.Titles
{
    public class CreateModel : PageModel
    {
        private readonly GroupProject.Data.ISPContext _context;

        public CreateModel(GroupProject.Data.ISPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Title Title { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Titles.Add(Title);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}