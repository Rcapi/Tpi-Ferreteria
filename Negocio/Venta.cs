using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class Venta
    {
        public static void AgregarVenta(Ventas venta)
        {
            DatosVenta datosVenta = new DatosVenta();
            datosVenta.AgregarVenta(venta);
        }

        public static Ventas BuscarVentaPorNumero(int numeroVenta)
        {
            DatosVenta datosVenta = new DatosVenta();
            return datosVenta.BuscarVentaPorNumero(numeroVenta);
        }

        public static List<Ventas> TraerTodasLasVentas()
        {
            DatosVenta datosVenta = new DatosVenta();
            return datosVenta.TraerTodasLasVentas();
        }

        public static void EliminarVenta(int numeroVenta)
        {
            DatosVenta datosVenta = new DatosVenta();
            datosVenta.EliminarVenta(numeroVenta);
        }

        public static void ModificarVenta(Ventas venta)
        {
            DatosVenta datosVenta = new DatosVenta();
            datosVenta.ModificarVenta(venta);
        }

        public static void AgregarVentaProducto(int numeroVenta, string codigoProducto)
        {
            DatosVentaProducto datosVentaProducto = new DatosVentaProducto();
            datosVentaProducto.AgregarProductoAVenta(numeroVenta, codigoProducto);
        }

        public static List<Entidades.Producto> ObtenerProductosDeVenta(int numeroVenta)
        {
            DatosVentaProducto datosVentaProducto = new DatosVentaProducto();
            return datosVentaProducto.ObtenerProductosDeVenta(numeroVenta);
        }

        public static void EliminarVentaProducto(int numeroVenta, string codigoProducto)
        {
            DatosVentaProducto datosVentaProducto = new DatosVentaProducto();
            datosVentaProducto.EliminarProductoDeVenta(numeroVenta, codigoProducto);
        }
    }
}
