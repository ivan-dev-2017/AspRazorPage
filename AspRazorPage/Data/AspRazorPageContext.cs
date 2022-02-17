#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspRazorPage.Models;

namespace AspRazorPage.Data
{
    public class AspRazorPageContext : DbContext
    {
        public AspRazorPageContext (DbContextOptions<AspRazorPageContext> options)
            : base(options)
        {
        }

        public DbSet<AspRazorPage.Models.Verdura> Verdura { get; set; }
    }
}
