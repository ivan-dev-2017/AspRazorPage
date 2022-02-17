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
    public class IndexModel : PageModel
    {
        private readonly AspRazorPage.Data.AspRazorPageContext _context;

        public IndexModel(AspRazorPage.Data.AspRazorPageContext context)
        {
            _context = context;
        }

        public IList<Verdura> Verdura { get;set; }

        public async Task OnGetAsync()
        {
            Verdura = await _context.Verdura.ToListAsync();
        }
    }
}
