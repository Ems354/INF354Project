using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupProject.Data;
using GroupProject.Entity;

namespace GroupProject.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly GroupProject.Data.ISPContext _context;

        public DetailsModel(GroupProject.Data.ISPContext context)
        {
            _context = context;
        }

        public Client Client { get; set; }
        public IList<Subscription> Subscription { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Clients
                .Include(c => c.Title).SingleOrDefaultAsync(m => m.ID == id);

            Subscription = await _context.Subscriptions
                .Where(s => s.ClientID == Client.ID)
                .Include(s => s.Client)
                .Include(s => s.Package).ToListAsync();

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
