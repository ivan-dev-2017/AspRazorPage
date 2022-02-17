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
    public class DetailsModel : PageModel
    {
        private readonly AspRazorPage.Data.AspRazorPageContext _context;

        public DetailsModel(AspRazorPage.Data.AspRazorPageContext context)
        {
            _context = context;
        }

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
    }
}
