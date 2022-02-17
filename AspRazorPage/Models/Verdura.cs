using System.ComponentModel.DataAnnotations;

namespace AspRazorPage.Models
{
    public class Verdura
    {
        [Key]
        public int IdVerdura { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
