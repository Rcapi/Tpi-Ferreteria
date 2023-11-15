using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio;
using Entidades;

namespace Web.Pages
{
    public class RegistroModel : PageModel
    {
        [BindProperty]
        public string Apellido { get; set; }

        [BindProperty]
        public string Dni { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Ciudad { get; set; }

        [BindProperty]
        public string Direccion { get; set; }

        [BindProperty]
        public string Clave { get; set; }

        [BindProperty]
        public string ConfirmaClave { get; set; }

        [BindProperty]
        public string Nombre { get; set; }

        [BindProperty]
        public string Telefono { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Clave != ConfirmaClave)
            {
                TempData["MensajeError"] = "La clave ingresada y la confirmación no coinciden";
            }
            else if (string.IsNullOrEmpty(Dni) || string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido) ||
                     string.IsNullOrEmpty(Telefono) || string.IsNullOrEmpty(Direccion) || string.IsNullOrEmpty(Ciudad) ||
                     string.IsNullOrEmpty(Clave) || string.IsNullOrEmpty(ConfirmaClave))
            {
                TempData["MensajeError"] = "Todos los campos deben estar llenos";
            }
            else
            {
                Entidades.Usuario usuario = new Entidades.Usuario
                {
                    Apellido = Apellido,
                    Dni = Dni,
                    Email = Email,
                    Ciudad = Ciudad,
                    Direccion = Direccion,
                    Clave = Clave,
                    Nombre = Nombre,
                    Rol = "Cliente",
                    Telefono = Telefono
                };

                Negocio.Usuario.AgregarUno(usuario);

                TempData["MensajeExito"] = "El cliente se ha registrado correctamente.";
                return RedirectToPage("/Index"); // Ajusta la ruta según la estructura de tu proyecto
            }

            return Page();
        }

        public IActionResult OnPostAtras()
        {
            return RedirectToPage("/Index"); // Ajusta la ruta según la estructura de tu proyecto
        }
    }
}
