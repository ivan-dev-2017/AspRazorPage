#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspRazorPage.Data;
using AspRazorPage.Models;

namespace AspRazorPage.Pages.Verduras
{
    public class DeleteModel : PageModel
    {
        private readonly AspRazorPage.Data.AspRazorPageContext _context;

        public DeleteModel(AspRazorPage.Data.AspRazorPageContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Verdura = await _context.Verdura.FindAsync(id);

            if (Verdura != null)
            {
                _context.Verdura.Remove(Verdura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
