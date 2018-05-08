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
    public class IndexModel : PageModel
    {
        private readonly GroupProject.Data.ISPContext _context;

        public IndexModel(GroupProject.Data.ISPContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }

        public IList<Package> Package { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            var packages = _context.Packages.Include(p => p.Connection);
            IQueryable<Package> packIQ = from t in packages select t;

            if (!string.IsNullOrEmpty(searchString))
            {
                packIQ = packIQ.Where(t => t.Name.ToUpper().Contains(searchString.ToUpper()) ||
                                      t.Cap.ToUpper().Contains(searchString.ToUpper()) || 
                                      t.Connection.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            packIQ = packIQ.OrderBy(t => t.Name);

            Package = await packIQ.AsNoTracking().ToListAsync();
        }
    }
}
