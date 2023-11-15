using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;

using System.Collections.Generic;




namespace Web.Pages
{
    public class CarritoModel : PageModel
    {





        public List<Producto> ListaCarrito { get; set; }
        public List<Producto> ListaProductos { get; set; }


        public void OnGet()
        {
            ListaCarrito = TempData["Carrito"] as List<Producto> ?? new List<Producto>();
            ListaProductos = TempData["ListaProductos"] as List<Producto> ?? new List<Producto>();
        }




        public IActionResult OnPostEliminarProducto(string codigo)
        {
            var productoAEliminar = ListaCarrito.FirstOrDefault(p => p.Codigo == codigo);

            if (productoAEliminar != null)
            {
                ListaCarrito.Remove(productoAEliminar);
                ActualizarTotal();

                var carritoBytes = JsonSerializer.SerializeToUtf8Bytes(ListaCarrito);
                HttpContext.Session.Set("Carrito", carritoBytes);

                return RedirectToPage("/Carrito");
            }

            return RedirectToPage("/Carrito");
        }

        public IActionResult OnPostRealizarCompra()
        {
            // Lógica para realizar la compra (puede incluir almacenamiento en una base de datos, etc.)

            // Limpiar el carrito después de realizar la compra
            HttpContext.Session.Remove("Carrito");

            return RedirectToPage("/Carrito");
        }

        private void ActualizarTotal()
        {
            Total = ListaCarrito.Sum(producto => producto.Precio);
        }

        public float Total { get; set; }
    }
}
