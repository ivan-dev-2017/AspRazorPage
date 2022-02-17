#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspRazorPage.Data;
using AspRazorPage.Models;

namespace AspRazorPage.Pages.Verduras
{
    public class EditModel : PageModel
    {
        private readonly AspRazorPage.Data.AspRazorPageContext _context;

        public EditModel(AspRazorPage.Data.AspRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Verdura Verdura { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Verdura = await _context.Verdura.FirstOrDefaultAsync(m => m.IdVerdura == id);

            if (Verdura == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Verdura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VerduraExists(Verdura.IdVerdura))
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

        private bool VerduraExists(int id)
        {
            return _context.Verdura.Any(e => e.IdVerdura == id);
        }
    }
}
