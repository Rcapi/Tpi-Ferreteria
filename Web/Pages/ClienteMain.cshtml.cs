using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Negocio;
using Entidades;
using System.Text.Json;

using System.Collections.Generic;



namespace Web.Pages
{
    public class ClienteMainModel : PageModel
    {
        public string NombreCliente { get; set; }
        public string DNI { get; set; }
        public List<Entidades.Producto> ListaProductos { get; set; }

        [BindProperty(SupportsGet = true)]
        public string NombreProducto { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedFiltro { get; set; }

        public List<SelectListItem> Filtros { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "PrecioAsc", Text = "Precio Ascendente" },
            new SelectListItem { Value = "PrecioDesc", Text = "Precio Descendente" },
            new SelectListItem { Value = "NombreAsc", Text = "Nombre A-Z" },
            new SelectListItem { Value = "NombreDesc", Text = "Nombre Z-A" },
        };

        public List<Entidades.Producto> Carrito
        {
            get
            {
                if (HttpContext.Session.TryGetValue("Carrito", out byte[] carritoBytes))
                {
                    return JsonSerializer.Deserialize<List<Entidades.Producto>>(carritoBytes);
                }
                return new List<Entidades.Producto>();
            }
            set
            {
                var carritoBytes = JsonSerializer.SerializeToUtf8Bytes(value);
                HttpContext.Session.Set("Carrito", carritoBytes);
            }
        }

        public IActionResult OnGet(string nombre, string dni)
        {
            NombreCliente = nombre;
            DNI = dni;
            ListaProductos = Negocio.Producto.RecuperarProductos();
            return Page();
        }

        public IActionResult OnPostCerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostBuscarProducto()
        {
            ListaProductos = Negocio.Producto.BuscarPorNombre(NombreProducto);
            return Page();
        }

        public IActionResult OnPostAgregarAlCarrito(string idProducto)
        {
            var producto = Negocio.Producto.BuscarPorCodigo(idProducto);

            if (producto != null)
            {
                if (int.TryParse(Request.Form[$"cantidad-{producto.Codigo}"], out int cantidad) && cantidad > 0 && cantidad <= producto.Stock)
                {
                    var carrito = Carrito;

                    // Utiliza Enumerable.Repeat para agregar múltiples instancias del producto al carrito
                    carrito.AddRange(Enumerable.Repeat(producto, cantidad));

                    Carrito = carrito;
                    MostrarMensaje($"Producto(s) agregado(s) al carrito. Cantidad: {cantidad}", "Mensaje");
                }
                else
                {
                    MostrarMensaje("La cantidad ingresada es inválida o supera el stock disponible.", "Error");
                }
            }
            else
            {
                MostrarMensaje("No se encontró un producto con el código ingresado.", "Error");
            }

            return RedirectToPage();
        }

        public IActionResult OnPostMostrarCarrito()
        {
            TempData["ListaProductos"] = ListaProductos; // ListaProductos es la lista que deseas enviar
            return RedirectToPage("/ClienteMain", new { ListaProductos });
        }

    



    public IActionResult OnPostFiltrar()
        {
            ListaProductos = Negocio.Producto.RecuperarProductos();
            AplicarFiltros();
            return Page();
        }

        private void AplicarFiltros()
        {
            if (!string.IsNullOrEmpty(SelectedFiltro))
            {
                ListaProductos = SelectedFiltro switch
                {
                    "PrecioAsc" => ListaProductos.OrderBy(item => item.Precio).ToList(),
                    "PrecioDesc" => ListaProductos.OrderByDescending(item => item.Precio).ToList(),
                    "NombreAsc" => ListaProductos.OrderBy(item => item.Nombre).ToList(),
                    "NombreDesc" => ListaProductos.OrderByDescending(item => item.Nombre).ToList(),
                    _ => ListaProductos,
                };
            }
        }

        private void MostrarMensaje(string mensaje, string tipo)
        {
            TempData[tipo] = mensaje;
        }
    }
}
