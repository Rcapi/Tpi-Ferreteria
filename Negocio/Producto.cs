using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class Producto
    {
       
        public static Entidades.Producto BuscarPorCodigo(string codigo)
        {
            Datos.DatosProducto producto = new Datos.DatosProducto(); 
            return producto.TraerProductoPorCodigo(codigo);
        }
        public static List<Entidades.Producto> RecuperarProductos()
        {
            DatosProducto producto = new DatosProducto();
            return producto.TraerTodos(); 
        }

        public static List<Entidades.Producto> BuscarPorNombre(string nombre)
        {
            Datos.DatosProducto producto = new DatosProducto();
            return producto.TraerProductoPorNombre(nombre); 
        }
        public static void EliminarPorCodigo(string codigo)
        {
            DatosProducto producto = new DatosProducto(); 
            producto.EliminarProducto(codigo);   
        }

        public static bool AgregarUno(Entidades.Producto producto)

        {
            Datos.DatosProducto datosProducto = new Datos.DatosProducto();

            return datosProducto.AgregarProducto(producto);
        }


    }
}
