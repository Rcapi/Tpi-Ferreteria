using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosElementoDeSujecion : Base
    {
        public List<ElementoDeSujecion> TraerTodosElementosDeSujecion()
        {
            List<ElementoDeSujecion> elementosDeSujecion = new List<ElementoDeSujecion>();

            try
            {
                AbriConexion();

                string query = "SELECT P.Codigo, P.Nombre, P.Descripcion, P.Precio, P.Stock, E.TipoElemento, E.Longitud, E.Capacidad " +
                               "FROM Producto P " +
                               "INNER JOIN ElementoDeSujecion E ON P.Codigo = E.Codigo";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ElementoDeSujecion elemento = new ElementoDeSujecion
                            (
                                reader["Codigo"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                (float)Convert.ToDouble(reader["Precio"]),
                                Convert.ToInt32(reader["Stock"]),
                                reader["TipoElemento"].ToString(),
                                Convert.ToInt32(reader["Longitud"]),
                                Convert.ToInt32(reader["Capacidad"])
                            );

                            elementosDeSujecion.Add(elemento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al traer todos los elementos de sujeción: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return elementosDeSujecion;
        }

        public bool ModificarElementoDeSujecion(ElementoDeSujecion elemento)
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
                    cmdProducto.Parameters.AddWithValue("@Descripcion", elemento.Descripcion);
                    cmdProducto.Parameters.AddWithValue("@Nombre", elemento.Nombre);
                    cmdProducto.Parameters.AddWithValue("@Precio", elemento.Precio);
                    cmdProducto.Parameters.AddWithValue("@Stock", elemento.Stock);
                    cmdProducto.Parameters.AddWithValue("@Codigo", elemento.Codigo);

                    int filasAfectadasProducto = cmdProducto.ExecuteNonQuery();

                    string queryElemento = "UPDATE ElementoDeSujecion SET " +
                                           "TipoElemento = @TipoElemento, " +
                                           "Longitud = @Longitud, " +
                                           "Capacidad = @Capacidad " +
                                           "WHERE Codigo = @Codigo";

                    using (SqlCommand cmdElemento = new SqlCommand(queryElemento, connection))
                    {
                        cmdElemento.Parameters.AddWithValue("@TipoElemento", elemento.TipoElemento);
                        cmdElemento.Parameters.AddWithValue("@Longitud", elemento.Longitud);
                        cmdElemento.Parameters.AddWithValue("@Capacidad", elemento.Capacidad);
                        cmdElemento.Parameters.AddWithValue("@Codigo", elemento.Codigo);

                        int filasAfectadasElemento = cmdElemento.ExecuteNonQuery();

                        return filasAfectadasProducto > 0 && filasAfectadasElemento > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar elemento de sujeción: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool EliminarElementoDeSujecion(string codigo)
        {
            try
            {
                AbriConexion();

                string queryElemento = "DELETE FROM ElementoDeSujecion WHERE Codigo = @Codigo";
                using (SqlCommand cmdElemento = new SqlCommand(queryElemento, connection))
                {
                    cmdElemento.Parameters.AddWithValue("@Codigo", codigo);

                    int filasAfectadasElemento = cmdElemento.ExecuteNonQuery();


                    if (filasAfectadasElemento > 0)
                    {
                        string queryProducto = "DELETE FROM Producto WHERE Codigo = @Codigo";
                        using (SqlCommand cmdProducto = new SqlCommand(queryProducto, connection))
                        {
                            cmdProducto.Parameters.AddWithValue("@Codigo", codigo);
                            cmdProducto.ExecuteNonQuery();
                        }
                    }

                    return filasAfectadasElemento > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar elemento de seguridad: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public ElementoDeSujecion TraerElementoDeSujecionPorCodigo(string codigo)
        {
            ElementoDeSujecion elemento = null;

            try
            {
                AbriConexion();

                string query = "SELECT P.Codigo, P.Nombre, P.Descripcion, P.Precio, P.Stock, E.TipoElemento, E.Longitud, E.Capacidad " +
                               "FROM Producto P " +
                               "INNER JOIN ElementoDeSujecion E ON P.Codigo = E.Codigo " +
                               "WHERE P.Codigo = @Codigo";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            elemento = new ElementoDeSujecion
                            (
                                reader["Codigo"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                (float)Convert.ToDouble(reader["Precio"]),
                                Convert.ToInt32(reader["Stock"]),
                                reader["TipoElemento"].ToString(),
                                Convert.ToInt32(reader["Longitud"]),
                                Convert.ToInt32(reader["Capacidad"])
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar elemento de sujeción: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return elemento;
        }

        public bool AgregarElementoDeSujecion(ElementoDeSujecion elemento)
        {
            try
            {
                AbriConexion();

              
                string queryProducto = "INSERT INTO Producto (Codigo, Nombre, Descripcion, Precio, Stock, TipoProducto) " +
                                       "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @TipoProducto)";

                SqlCommand cmdProducto = new SqlCommand(queryProducto, connection);

                cmdProducto.Parameters.AddWithValue("@Codigo", elemento.Codigo);
                cmdProducto.Parameters.AddWithValue("@Nombre", elemento.Nombre);
                cmdProducto.Parameters.AddWithValue("@Descripcion", elemento.Descripcion);
                cmdProducto.Parameters.AddWithValue("@Precio", elemento.Precio);
                cmdProducto.Parameters.AddWithValue("@Stock", elemento.Stock);
                cmdProducto.Parameters.AddWithValue("@TipoProducto", "ElementoDeSujecion");

                cmdProducto.ExecuteNonQuery();

            
                string queryElemento = "INSERT INTO ElementoDeSujecion (Codigo, TipoElemento, Longitud, Capacidad) " +
                                       "VALUES (@Codigo, @TipoElemento, @Longitud, @Capacidad)";

                SqlCommand cmdElemento = new SqlCommand(queryElemento, connection);
                cmdElemento.Parameters.AddWithValue("@Codigo", elemento.Codigo);
                cmdElemento.Parameters.AddWithValue("@TipoElemento", elemento.TipoElemento);
                cmdElemento.Parameters.AddWithValue("@Longitud", elemento.Longitud);
                cmdElemento.Parameters.AddWithValue("@Capacidad", elemento.Capacidad);

                cmdElemento.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar elemento de sujeción: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}

