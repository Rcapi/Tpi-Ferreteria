using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DatosHerramientaElectrica : Base
    {
        public bool AgregarHerramientaElectrica(Entidades.HerramientaElectrica herramientaElectrica)
        {
            try
            {
                AbriConexion();

                // Agregar a la tabla Producto
                string queryProducto = "INSERT INTO Producto (Codigo, Nombre, Descripcion, Precio, Stock, TipoProducto) " +
                                       "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @TipoProducto)";

                using (SqlCommand cmdProducto = new SqlCommand(queryProducto, connection))
                {
                    cmdProducto.Parameters.AddWithValue("@Codigo", herramientaElectrica.Codigo);
                    cmdProducto.Parameters.AddWithValue("@Nombre", herramientaElectrica.Nombre);
                    cmdProducto.Parameters.AddWithValue("@Descripcion", herramientaElectrica.Descripcion);
                    cmdProducto.Parameters.AddWithValue("@Precio", herramientaElectrica.Precio);
                    cmdProducto.Parameters.AddWithValue("@Stock", herramientaElectrica.Stock);
                    cmdProducto.Parameters.AddWithValue("@TipoProducto", "HerramientaElectrica");

                    cmdProducto.ExecuteNonQuery();
                }

                // Agregar a la tabla Herramienta
                string queryHerramienta = "INSERT INTO Herramienta (Codigo, Modelo) " +
                                          "VALUES (@Codigo, @Modelo)";

                using (SqlCommand cmdHerramienta = new SqlCommand(queryHerramienta, connection))
                {
                    cmdHerramienta.Parameters.AddWithValue("@Codigo", herramientaElectrica.Codigo);
                    cmdHerramienta.Parameters.AddWithValue("@Modelo", herramientaElectrica.Modelo);

                    cmdHerramienta.ExecuteNonQuery();
                }

                // Agregar a la tabla HerramientaElectrica
                string queryHerramientaElectrica = "INSERT INTO HerramientaElectrica (Codigo, Potencia,TipoHerramienta,Modelo) " +
                                                   "VALUES (@Codigo, @Potencia, @TipoHerramienta, @Modelo)";

                using (SqlCommand cmdHerramientaElectrica = new SqlCommand(queryHerramientaElectrica, connection))
                {
                    cmdHerramientaElectrica.Parameters.AddWithValue("@Codigo", herramientaElectrica.Codigo);
                    cmdHerramientaElectrica.Parameters.AddWithValue("@Potencia", herramientaElectrica.Potencia);
                    cmdHerramientaElectrica.Parameters.AddWithValue("@TipoHerramienta", herramientaElectrica.TipoHerramienta);
                    cmdHerramientaElectrica.Parameters.AddWithValue("@Modelo", herramientaElectrica.Modelo);
                    cmdHerramientaElectrica.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar herramienta eléctrica: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }


        public List<HerramientaElectrica> TraerTodos()
        {
            List<HerramientaElectrica> herramientas = new List<HerramientaElectrica>();

            try
            {
                AbriConexion();

                string query = "SELECT Hr.Codigo, Nombre, TipoHerramienta, Potencia, Descripcion, Precio, Stock, TipoProducto, Modelo " +
                               "FROM HerramientaElectrica Hr " +
                               "LEFT JOIN Producto pro ON Hr.Codigo = pro.Codigo;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HerramientaElectrica herramienta = new HerramientaElectrica
                            (
                                reader["Codigo"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                (float)Convert.ToDouble(reader["Precio"]),
                                Convert.ToInt32(reader["Stock"]),
                                reader["Modelo"].ToString(),
                                reader["TipoHerramienta"].ToString(),
                                reader["Potencia"].ToString()
                            );

                            herramientas.Add(herramienta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al traer todos las herramientas eléctricas: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return herramientas;
        }


        public bool EliminarHerramienta(string codigo)
        {
            try
            {
                AbriConexion();

                string query = "DELETE FROM HerramientaElectrica WHERE Codigo = @Codigo; " +
                                "DELETE FROM Herramienta Where Codigo = @Codigo " +
                               "DELETE FROM Producto WHERE Codigo = @Codigo;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar herramienta eléctrica: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public HerramientaElectrica TraerHerramientaPorCodigo(string codigo)
        {
            HerramientaElectrica herramienta = null;

            try
            {
                AbriConexion();

                string query = "SELECT Hr.Codigo, Nombre, TipoHerramienta, Potencia, Descripcion, Precio, Stock, TipoProducto, Modelo " +
                               "FROM HerramientaElectrica Hr " +
                               "LEFT JOIN Producto pro ON Hr.Codigo = pro.Codigo " +
                               "WHERE Hr.Codigo = @Codigo;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                             herramienta = new HerramientaElectrica
                          (
                              reader["Codigo"].ToString(),
                              reader["Nombre"].ToString(),
                              reader["Descripcion"].ToString(),
                              (float)Convert.ToDouble(reader["Precio"]),
                              Convert.ToInt32(reader["Stock"]),
                              reader["Modelo"].ToString(),
                              reader["TipoHerramienta"].ToString(),
                              reader["Potencia"].ToString()
                          );
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ninguna herramienta con el código proporcionado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar herramienta eléctrica: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return herramienta;
        }

        public bool ModificarHerramientaElectrica(Entidades.HerramientaElectrica herramientaElectrica)
        {
            try
            {
                AbriConexion();

                // Modificar en la tabla Producto
                string queryProducto = "UPDATE Producto SET Nombre = @Nombre, Descripcion = @Descripcion, " +
                                       "Precio = @Precio, Stock = @Stock " +
                                       "WHERE Codigo = @Codigo";

                using (SqlCommand cmdProducto = new SqlCommand(queryProducto, connection))
                {
                    cmdProducto.Parameters.AddWithValue("@Codigo", herramientaElectrica.Codigo);
                    cmdProducto.Parameters.AddWithValue("@Nombre", herramientaElectrica.Nombre);
                    cmdProducto.Parameters.AddWithValue("@Descripcion", herramientaElectrica.Descripcion);
                    cmdProducto.Parameters.AddWithValue("@Precio", herramientaElectrica.Precio);
                    cmdProducto.Parameters.AddWithValue("@Stock", herramientaElectrica.Stock);

                    cmdProducto.ExecuteNonQuery();
                }

                // Modificar en la tabla Herramienta
                string queryHerramienta = "UPDATE Herramienta SET Modelo = @Modelo " +
                                          "WHERE Codigo = @Codigo";

                using (SqlCommand cmdHerramienta = new SqlCommand(queryHerramienta, connection))
                {
                    cmdHerramienta.Parameters.AddWithValue("@Codigo", herramientaElectrica.Codigo);
                    cmdHerramienta.Parameters.AddWithValue("@Modelo", herramientaElectrica.Modelo);

                    cmdHerramienta.ExecuteNonQuery();
                }

                // Modificar en la tabla HerramientaElectrica
                string queryHerramientaElectrica = "UPDATE HerramientaElectrica SET Potencia = @Potencia, " +
                                                   "TipoHerramienta = @TipoHerramienta " + "Modelo = @Modelo" +
                                                   "WHERE Codigo = @Codigo";

                using (SqlCommand cmdHerramientaElectrica = new SqlCommand(queryHerramientaElectrica, connection))
                {
                    cmdHerramientaElectrica.Parameters.AddWithValue("@Codigo", herramientaElectrica.Codigo);
                    cmdHerramientaElectrica.Parameters.AddWithValue("@Potencia", herramientaElectrica.Potencia);
                    cmdHerramientaElectrica.Parameters.AddWithValue("@TipoHerramienta", herramientaElectrica.TipoHerramienta);
                    cmdHerramientaElectrica.Parameters.AddWithValue("@Modelo", herramientaElectrica.Modelo);

                    cmdHerramientaElectrica.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar herramienta eléctrica: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

    }

}

