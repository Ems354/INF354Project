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
    public class IndexModel : PageModel
    {
        private readonly GroupProject.Data.ISPContext _context;

        public IndexModel(GroupProject.Data.ISPContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }

        public IList<Client> Client { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            var clients = _context.Clients.Include(c => c.Title);
            IQueryable<Client> clIQ = from c in clients select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                clIQ = clIQ.Where(c => c.Name.ToUpper().Contains(searchString.ToUpper()) || 
                                  c.Surname.ToUpper().Contains(searchString.ToUpper()) || 
                                  c.Number.ToUpper().Contains(searchString.ToUpper()) || 
                                  c.Title.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            clIQ = clIQ.OrderBy(t => t.Name);

            Client = await clIQ.AsNoTracking().ToListAsync();
        }
    }
}
