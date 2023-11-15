using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosVentaProducto : Base
    {
        public void AgregarProductoAVenta(int numeroVenta, string codigoProducto)
        {
            try
            {
                AbriConexion();

                string query = "INSERT INTO VentasProductos (NumeroVenta, CodigoProducto) " +
                               "VALUES (@NumeroVenta, @CodigoProducto)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NumeroVenta", numeroVenta);
                cmd.Parameters.AddWithValue("@CodigoProducto", codigoProducto);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar producto a la venta: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<Producto> ObtenerProductosDeVenta(int numeroVenta)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                AbriConexion();

                string queryProductos = "SELECT p.* FROM VentasProductos vp " +
                                        "JOIN Productos p ON vp.CodigoProducto = p.Codigo " +
                                        "WHERE vp.NumeroVenta = @NumeroVenta";

                SqlCommand cmdProductos = new SqlCommand(queryProductos, connection);
                cmdProductos.Parameters.AddWithValue("@NumeroVenta", numeroVenta);

                using (SqlDataReader readerProductos = cmdProductos.ExecuteReader())
                {
                    while (readerProductos.Read())
                    {
                        Producto producto = new Producto
                        (
                            readerProductos["Codigo"].ToString(),
                            readerProductos["Nombre"].ToString(),
                            readerProductos["Descripcion"].ToString(),
                            (float)Convert.ToDouble(readerProductos["Precio"]),
                            Convert.ToInt32(readerProductos["Stock"]),
                            readerProductos["TipoProducto"].ToString()
                        );

                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener productos de la venta: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return productos;
        }

        public void EliminarProductoDeVenta(int numeroVenta, string codigoProducto)
        {
            try
            {
                AbriConexion();

                string query = "DELETE FROM VentasProductos " +
                               "WHERE NumeroVenta = @NumeroVenta AND CodigoProducto = @CodigoProducto";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NumeroVenta", numeroVenta);
                cmd.Parameters.AddWithValue("@CodigoProducto", codigoProducto);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar producto de la venta: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
