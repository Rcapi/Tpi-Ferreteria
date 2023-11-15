using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Negocio;
using Entidades;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            try
            {
                Entidades.Usuario usuarioEncontrado = Negocio.Usuario.BuscarPorDni(Username);

                if (usuarioEncontrado != null && usuarioEncontrado.Clave == Password)
                {
                    if (usuarioEncontrado.Rol == "Cliente")
                    {
                        TempData["MensajeBienvenida"] = "¡Bienvenido, cliente!";
                        return RedirectToPage("/ClienteMain", new { nombre = usuarioEncontrado.Nombre, dni = usuarioEncontrado.Dni });
                    }
                    else if (usuarioEncontrado.Rol == "Empleado")
                    {
                        TempData["MensajeBienvenida"] = "¡Bienvenido, empleado!";
                        return RedirectToPage("/EmpleadoMain", new { nombre = usuarioEncontrado.Nombre, dni = usuarioEncontrado.Dni });
                    }
                    else if (usuarioEncontrado.Rol == "Admin")
                    {
                        TempData["MensajeBienvenida"] = "¡Bienvenido, admin!";
                        return RedirectToPage("/AdminMain", new { nombre = usuarioEncontrado.Nombre, dni = usuarioEncontrado.Dni });
                    }
                }
                else
                {
                    TempData["MensajeError"] = "Usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.";
                }
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = "Error de conexión a la base de datos: " + ex.Message;
            }

            return Page();
        }

        public IActionResult OnPostRegistro()
        {
            // Lógica para redirigir a la página de registro
            return RedirectToPage("/Registro"); // Ajusta la ruta según la estructura de tu proyecto
        }
    }
}
