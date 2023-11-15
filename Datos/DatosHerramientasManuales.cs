using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosHerramientaDeMano : Base
    {
        public bool AgregarHerramientaManual(Entidades.HerramientaDeMano herramientaManual)
        {
            try
            {
                AbriConexion();

                // Agregar a la tabla Producto
                string queryProducto = "INSERT INTO Producto (Codigo, Nombre, Descripcion, Precio, Stock, TipoProducto) " +
                                       "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @TipoProducto)";

                using (SqlCommand cmdProducto = new SqlCommand(queryProducto, connection))
                {
                    cmdProducto.Parameters.AddWithValue("@Codigo", herramientaManual.Codigo);
                    cmdProducto.Parameters.AddWithValue("@Nombre", herramientaManual.Nombre);
                    cmdProducto.Parameters.AddWithValue("@Descripcion", herramientaManual.Descripcion);
                    cmdProducto.Parameters.AddWithValue("@Precio", herramientaManual.Precio);
                    cmdProducto.Parameters.AddWithValue("@Stock", herramientaManual.Stock);
                    cmdProducto.Parameters.AddWithValue("@TipoProducto", "HerramientaManual");

                    cmdProducto.ExecuteNonQuery();
                }

                // Agregar a la tabla Herramienta
                string queryHerramienta = "INSERT INTO Herramienta (Codigo, Modelo) " +
                                          "VALUES (@Codigo, @Modelo)";

                using (SqlCommand cmdHerramienta = new SqlCommand(queryHerramienta, connection))
                {
                    cmdHerramienta.Parameters.AddWithValue("@Codigo", herramientaManual.Codigo);
                    cmdHerramienta.Parameters.AddWithValue("@Modelo", herramientaManual.Modelo);

                    cmdHerramienta.ExecuteNonQuery();
                }

                // Agregar a la tabla HerramientaManual
                string queryHerramientaManual = "INSERT INTO HerramientaManual (Codigo, TipoHerramienta,Modelo) " +
                                                "VALUES (@Codigo, @TipoHerramienta,@Modelo)";

                using (SqlCommand cmdHerramientaManual = new SqlCommand(queryHerramientaManual, connection))
                {
                    cmdHerramientaManual.Parameters.AddWithValue("@Codigo", herramientaManual.Codigo);
                    cmdHerramientaManual.Parameters.AddWithValue("@TipoHerramienta", herramientaManual.TipoHerramienta);
                    cmdHerramientaManual.Parameters.AddWithValue("@Modelo", herramientaManual.Modelo);

                    cmdHerramientaManual.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar herramienta manual: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<HerramientaDeMano> TraerTodosHerramientaDeMano()
        {
            List<HerramientaDeMano> herramientasDeMano = new List<HerramientaDeMano>();

            try
            {
                AbriConexion();

                string query = "SELECT Hm.Codigo, Nombre, TipoHerramienta, Descripcion, Precio, Stock, TipoProducto, Modelo " +
                               "FROM HerramientaManual Hm " +
                               "LEFT JOIN Producto pro ON Hm.Codigo = pro.Codigo;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HerramientaDeMano herramientaDeMano = new HerramientaDeMano
                            (
                                reader["Codigo"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                (float)Convert.ToDouble(reader["Precio"]),
                                Convert.ToInt32(reader["Stock"]),
                                reader["Modelo"].ToString(),
                                reader["TipoHerramienta"].ToString()
                            );

                            herramientasDeMano.Add(herramientaDeMano);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al traer todas las herramientas de mano: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return herramientasDeMano;
        }

        public bool ModificarHerramientaDeMano(HerramientaDeMano herramientaDeMano)
        {
            try
            {
                AbriConexion();

                string queryProducto = "UPDATE Producto SET " +
                                       "Descripcion = @Descripcion, " +
                                       "Nombre = @Nombre, " +
                                       "Precio = @Precio, " +
                                       "Stock = @Stock " +
                                       "WHERE Codigo = @Codigo";

                using (SqlCommand cmdProducto = new SqlCommand(queryProducto, connection))
                {
                    cmdProducto.Parameters.AddWithValue("@Descripcion", herramientaDeMano.Descripcion);
                    cmdProducto.Parameters.AddWithValue("@Nombre", herramientaDeMano.Nombre);
                    cmdProducto.Parameters.AddWithValue("@Precio", herramientaDeMano.Precio);
                    cmdProducto.Parameters.AddWithValue("@Stock", herramientaDeMano.Stock);
                    cmdProducto.Parameters.AddWithValue("@Codigo", herramientaDeMano.Codigo);

                    int filasAfectadasProducto = cmdProducto.ExecuteNonQuery();

                    string queryHerramientaDeMano = "UPDATE HerramientaManual SET " +
                                                   "Modelo = @Modelo, " +
                                                   "TipoHerramienta = @TipoHerramienta " +
                                                   "WHERE Codigo = @Codigo";

                    using (SqlCommand cmdHerramientaDeMano = new SqlCommand(queryHerramientaDeMano, connection))
                    {
                        cmdHerramientaDeMano.Parameters.AddWithValue("@Modelo", herramientaDeMano.Modelo);
                        cmdHerramientaDeMano.Parameters.AddWithValue("@TipoHerramienta", herramientaDeMano.TipoHerramienta);
                        cmdHerramientaDeMano.Parameters.AddWithValue("@Codigo", herramientaDeMano.Codigo);

                        int filasAfectadasHerramientaDeMano = cmdHerramientaDeMano.ExecuteNonQuery();

                        return filasAfectadasProducto > 0 && filasAfectadasHerramientaDeMano > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar herramienta de mano: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool EliminarHerramientaDeMano(string codigo)
        {
            try
            {
                AbriConexion();

                string query = "DELETE FROM HerramientaManual WHERE Codigo = @Codigo; " +
                               "DELETE FROM Herramienta WHERE Codigo = @Codigo;" +
                               "DELETE FROM Producto WHERE Codigo = @Codigo" 
                               ;

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar herramienta de mano: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public HerramientaDeMano TraerHerramientaDeManoPorCodigo(string codigo)
        {
            HerramientaDeMano herramientaDeMano = null;

            try
            {
                AbriConexion();

                string query = "SELECT Hm.Codigo, Nombre, TipoHerramienta, Descripcion, Precio, Stock, TipoProducto, Modelo " +
                               "FROM HerramientaManual Hm " +
                               "LEFT JOIN Producto pro ON Hm.Codigo = pro.Codigo " +
                               "WHERE Hm.Codigo = @Codigo;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            herramientaDeMano = new HerramientaDeMano
                            (
                                reader["Codigo"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                (float)Convert.ToDouble(reader["Precio"]),
                                Convert.ToInt32(reader["Stock"]),
                                reader["Modelo"].ToString(),
                                reader["TipoHerramienta"].ToString()
                            );
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ninguna herramienta de mano con el código proporcionado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar herramienta de mano: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return herramientaDeMano;
        }
    }
}

    

