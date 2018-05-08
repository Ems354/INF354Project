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

namespace GroupProject.Pages.Subscriptions
{
    public class EditModel : PageModel
    {
        private readonly GroupProject.Data.ISPContext _context;

        public EditModel(GroupProject.Data.ISPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subscription Subscription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subscription = await _context.Subscriptions
                .Include(s => s.Client)
                .Include(s => s.Package).SingleOrDefaultAsync(m => m.SubscriptionID == id);

            if (Subscription == null)
            {
                return NotFound();
            }

            var clients = _context.Clients.Select(client => new
            {
                ID = client.ID,
                FullName = $"{client.Name} {client.Surname}"
            })
            .ToList();


            ViewData["ClientID"] = new SelectList(clients, "ID", "FullName");
            ViewData["PackageID"] = new SelectList(_context.Packages, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Subscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(Subscription.SubscriptionID))
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

        private bool SubscriptionExists(int id)
        {
            return _context.Subscriptions.Any(e => e.SubscriptionID == id);
        }
    }
}
