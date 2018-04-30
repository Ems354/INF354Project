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

        public IList<Package> Package { get;set; }

        public async Task OnGetAsync()
        {
            Package = await _context.Packages
                .Include(p => p.Connection).ToListAsync();
        }
    }
}
