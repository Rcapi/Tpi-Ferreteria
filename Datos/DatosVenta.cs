using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosVenta : Base
    {
        public void AgregarVenta(Ventas venta)
        {
            

            try
            {
                AbriConexion();
                

                // Agregar la venta
                string queryVenta = "INSERT INTO Ventas (FechaHora, DniCliente, Total, MetodoPago) " +
                                    "VALUES (@FechaHora, @DniCliente, @Total, @MetodoPago); SELECT SCOPE_IDENTITY();";

                SqlCommand cmdVenta = new SqlCommand(queryVenta, connection);
                cmdVenta.Parameters.AddWithValue("@FechaHora", venta.FechaHora);
                cmdVenta.Parameters.AddWithValue("@DniCliente", venta.DniCliente);
                cmdVenta.Parameters.AddWithValue("@Total", venta.Total);
                cmdVenta.Parameters.AddWithValue("@MetodoPago", venta.MetodoDePago);

                int idVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());

                
                string queryProductosVenta = "INSERT INTO VentasProductos (NumeroVenta, CodigoProducto) " +
                                             "VALUES (@NumeroVenta, @CodigoProducto)";

                foreach (Producto producto in venta.Productos)
                {
                    SqlCommand cmdProductosVenta = new SqlCommand(queryProductosVenta, connection);
                    cmdProductosVenta.Parameters.AddWithValue("@NumeroVenta", idVenta);
                    cmdProductosVenta.Parameters.AddWithValue("@CodigoProducto", producto.Codigo);

                    cmdProductosVenta.ExecuteNonQuery();
                }

               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar venta: " + ex.Message);
               
            }
            finally
            {
                CerrarConexion();
            }
        }

        public Ventas BuscarVentaPorNumero(int numeroVenta)
        {
            Ventas venta = null;

            try
            {
                AbriConexion();

                string queryVenta = "SELECT * FROM Ventas WHERE NumeroVenta = @NumeroVenta";
                SqlCommand cmdVenta = new SqlCommand(queryVenta, connection);
                cmdVenta.Parameters.AddWithValue("@NumeroVenta", numeroVenta);

                using (SqlDataReader readerVenta = cmdVenta.ExecuteReader())
                {
                    if (readerVenta.Read())
                    {
                        venta = new Ventas
                        {
                            NumeroVenta = Convert.ToInt32(readerVenta["NumeroVenta"]),
                            FechaHora = Convert.ToDateTime(readerVenta["FechaHora"]),
                            DniCliente = readerVenta["DniCliente"].ToString(),
                            Total = Convert.ToDecimal(readerVenta["Total"]),
                            MetodoDePago = readerVenta["MetodoPago"].ToString(),
                            Productos = ObtenerProductosDeVenta(numeroVenta)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar venta: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return venta;
        }

        private List<Producto> ObtenerProductosDeVenta(int numeroVenta)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
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

            return productos;
        }

        public List<Ventas> TraerTodasLasVentas()
        {
            List<Ventas> ventas = new List<Ventas>();

            try
            {
                AbriConexion();

                string queryVentas = "SELECT * FROM Ventas";
                SqlCommand cmdVentas = new SqlCommand(queryVentas, connection);

                using (SqlDataReader readerVentas = cmdVentas.ExecuteReader())
                {
                    while (readerVentas.Read())
                    {
                        Ventas venta = new Ventas
                        {
                            NumeroVenta = Convert.ToInt32(readerVentas["NumeroVenta"]),
                            FechaHora = Convert.ToDateTime(readerVentas["FechaHora"]),
                            DniCliente = readerVentas["DniCliente"].ToString(),
                            Total = Convert.ToDecimal(readerVentas["Total"]),
                            MetodoDePago = readerVentas["MetodoPago"].ToString(),
                            Productos = ObtenerProductosDeVenta(Convert.ToInt32(readerVentas["NumeroVenta"]))
                        };

                        ventas.Add(venta);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al traer todas las ventas: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return ventas;
        }

        public void EliminarVenta(int numeroVenta)
        {
            SqlTransaction transaction = null;

            try
            {
                AbriConexion();
                transaction = connection.BeginTransaction();

                // Eliminar productos asociados a la venta en la tabla intermedia
                string queryEliminarProductos = "DELETE FROM VentasProductos WHERE NumeroVenta = @NumeroVenta";
                SqlCommand cmdEliminarProductos = new SqlCommand(queryEliminarProductos, connection, transaction);
                cmdEliminarProductos.Parameters.AddWithValue("@NumeroVenta", numeroVenta);
                cmdEliminarProductos.ExecuteNonQuery();

                // Eliminar la venta
                string queryEliminarVenta = "DELETE FROM Ventas WHERE NumeroVenta = @NumeroVenta";
                SqlCommand cmdEliminarVenta = new SqlCommand(queryEliminarVenta, connection, transaction);
                cmdEliminarVenta.Parameters.AddWithValue("@NumeroVenta", numeroVenta);
                cmdEliminarVenta.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar venta: " + ex.Message);
                transaction?.Rollback();
            }
            finally
            {
                CerrarConexion();
            }
        }

        public void ModificarVenta(Ventas venta)
        {
            SqlTransaction transaction = null;

            try
            {
                AbriConexion();
                transaction = connection.BeginTransaction();

                // Modificar la venta
                string queryModificarVenta = "UPDATE Ventas SET FechaHora = @FechaHora, " +
                                             "DniCliente = @DniCliente, Total = @Total, MetodoPago = @MetodoPago " +
                                             "WHERE NumeroVenta = @NumeroVenta";

                SqlCommand cmdModificarVenta = new SqlCommand(queryModificarVenta, connection, transaction);
                cmdModificarVenta.Parameters.AddWithValue("@NumeroVenta", venta.NumeroVenta);
                cmdModificarVenta.Parameters.AddWithValue("@FechaHora", venta.FechaHora);
                cmdModificarVenta.Parameters.AddWithValue("@DniCliente", venta.DniCliente);
                cmdModificarVenta.Parameters.AddWithValue("@Total", venta.Total);
                cmdModificarVenta.Parameters.AddWithValue("@MetodoPago", venta.MetodoDePago);
                cmdModificarVenta.ExecuteNonQuery();

                // Eliminar productos asociados a la venta en la tabla intermedia
                string queryEliminarProductos = "DELETE FROM VentasProductos WHERE NumeroVenta = @NumeroVenta";
                SqlCommand cmdEliminarProductos = new SqlCommand(queryEliminarProductos, connection, transaction);
                cmdEliminarProductos.Parameters.AddWithValue("@NumeroVenta", venta.NumeroVenta);
                cmdEliminarProductos.ExecuteNonQuery();

                // Agregar los productos actualizados asociados a la venta en la tabla intermedia
                string queryProductosVenta = "INSERT INTO VentasProductos (NumeroVenta, CodigoProducto) " +
                                             "VALUES (@NumeroVenta, @CodigoProducto)";

                foreach (Producto producto in venta.Productos)
                {
                    SqlCommand cmdProductosVenta = new SqlCommand(queryProductosVenta, connection, transaction);
                    cmdProductosVenta.Parameters.AddWithValue("@NumeroVenta", venta.NumeroVenta);
                    cmdProductosVenta.Parameters.AddWithValue("@CodigoProducto", producto.Codigo);
                    cmdProductosVenta.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar venta: " + ex.Message);
                transaction?.Rollback();
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
