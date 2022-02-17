#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspRazorPage.Data;
using AspRazorPage.Models;

namespace AspRazorPage.Pages.Verduras
{
    public class CreateModel : PageModel
    {
        private readonly AspRazorPage.Data.AspRazorPageContext _context;

        public CreateModel(AspRazorPage.Data.AspRazorPageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Verdura Verdura { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Verdura.Add(Verdura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
