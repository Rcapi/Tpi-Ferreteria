using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio;

namespace Web.Pages
{
    public class EmpleadoMainModel : PageModel
    {
        public string NombreEmpleado { get; set; }
        public string DNI { get; set; }

        public void OnGet(string nombre, string dni)
        {
            NombreEmpleado = nombre;
            DNI = dni;
        }

        public IActionResult OnPostCerrarSesion()
        {
            return RedirectToPage("/Index"); // Ajusta la ruta según la estructura de tu proyecto
        }

        public IActionResult OnPostABMProductos()
        {
            return RedirectToPage("/ABMProductos"); // Ajusta la ruta según la estructura de tu proyecto
        }

        public IActionResult OnPostABMClientes()
        {
            return RedirectToPage("/ABMClientes"); // Ajusta la ruta según la estructura de tu proyecto
        }

        public IActionResult OnPostDatosUsuarioEmpleado()
        {
            return RedirectToPage("/DatosUsuarioEmpleado", new { dni = DNI }); // Ajusta la ruta según la estructura de tu proyecto
        }

        public IActionResult OnPostVenta()
        {
            return RedirectToPage("/Venta"); // Ajusta la ruta según la estructura de tu proyecto
        }

        public IActionResult OnPostVerVentas()
        {
            return RedirectToPage("/VerVentas"); // Ajusta la ruta según la estructura de tu proyecto
        }
    }
}
