using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class AdminMainModel : PageModel
    {
        public string NombreAdmin { get; set; }
        public string DniAdmin { get; set; }

        public void OnGet(string nombre, string dni)
        {
            NombreAdmin = nombre;
            DniAdmin = dni;
        }

        public IActionResult OnPostCerrarSesion()
        {
            return RedirectToPage("/Index");
        }
    }
}
