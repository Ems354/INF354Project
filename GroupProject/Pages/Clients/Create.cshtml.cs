using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroupProject.Data;
using GroupProject.Entity;

namespace GroupProject.Pages.Clients
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
            ViewData["TitleID"] = new SelectList(_context.Titles, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //check if user exists
            var exists = _context.Clients.Where(c => c.Number == Client.Number && c.Name.ToUpper() == Client.Name.ToUpper() && c.Surname.ToUpper() == Client.Surname.ToUpper());

            if (exists.Count() > 0)
            {
                //client exits
                ModelState.AddModelError("Error", "User already exists");
                ViewData["TitleID"] = new SelectList(_context.Titles, "ID", "Name");
                return Page();
            }
            else
            {
                
                _context.Clients.Add(Client);
                
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        }
    }
}