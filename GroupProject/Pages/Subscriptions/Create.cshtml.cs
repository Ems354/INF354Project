using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroupProject.Data;
using GroupProject.Entity;

namespace GroupProject.Pages.Subscriptions
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
        ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ID");
        ViewData["PackageID"] = new SelectList(_context.Packages, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Subscription Subscription { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Subscriptions.Add(Subscription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}