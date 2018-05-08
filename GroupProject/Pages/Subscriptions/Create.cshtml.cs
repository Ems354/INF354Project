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
            var clients = _context.Clients.Select(client => new
            {
                ID = client.ID,
                FullName = $"{client.Name} {client.Surname}"
            })
            .ToList();

            var id = this.Request.Query["id"].ToString();              ViewData["PackageID"] = new SelectList(_context.Packages, "ID", "Name");             ViewData["ClientID"] = new SelectList(clients, "ID", "FullName", id); 
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