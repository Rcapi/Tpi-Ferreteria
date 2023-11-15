using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosElementoDeSeguridad : Base
    {
        

        public List<Entidades.ElementoDeSeguridad> TraerTodos()
        {
            List<Entidades.ElementoDeSeguridad> elementos = new List<Entidades.ElementoDeSeguridad>();

            try
            {
                AbriConexion();

                string query = "SELECT P.Codigo, P.Nombre, P.Descripcion, P.Precio, P.Stock, E.Talle, E.Normativa, E.TipoEquipo, E.Peso " +
                               "FROM Producto P " +
                               "INNER JOIN EquipoDeSeguridad E ON P.Codigo = E.Codigo";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Entidades.ElementoDeSeguridad elemento = new Entidades.ElementoDeSeguridad
                            (
                                reader["Codigo"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                (float)Convert.ToDouble(reader["Precio"]),
                                Convert.ToInt32(reader["Stock"]),
                                reader["Talle"].ToString(),
                                reader["Normativa"].ToString(),
                                reader["TipoEquipo"].ToString(),
                                (float)Convert.ToDouble(reader["Peso"])
                            );

                            elementos.Add(elemento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al traer todos los elementos de seguridad: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return elementos;
        }

        public bool EliminarElemento(string codigo)
        {
            try
            {
                AbriConexion();

                // Eliminar de la tabla EquipoDeSeguridad
                string queryElemento = "DELETE FROM EquipoDeSeguridad WHERE Codigo = @Codigo";
                using (SqlCommand cmdElemento = new SqlCommand(queryElemento, connection))
                {
                    cmdElemento.Parameters.AddWithValue("@Codigo", codigo);

                    int filasAfectadasElemento = cmdElemento.ExecuteNonQuery();

                    // Eliminar de la tabla Producto solo si se eliminó correctamente de EquipoDeSeguridad
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

        public ElementoDeSeguridad TraerElementoPorCodigo(string codigo)
        {
            ElementoDeSeguridad elemento = null;

            try
            {
                AbriConexion();

                string query = "SELECT P.Codigo, P.Nombre, P.Descripcion, P.Precio, P.Stock, E.Talle, E.Normativa, E.TipoEquipo, E.Peso " +
                               "FROM Producto P " +
                               "INNER JOIN EquipoDeSeguridad E ON P.Codigo = E.Codigo " +
                               "WHERE P.Codigo = @Codigo";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            elemento = new ElementoDeSeguridad
                            (
                                reader["Codigo"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                (float)Convert.ToDouble(reader["Precio"]),
                                Convert.ToInt32(reader["Stock"]),
                                reader["Talle"].ToString(),
                                reader["Normativa"].ToString(),
                                reader["TipoEquipo"].ToString(),
                                (float)Convert.ToDouble(reader["Peso"])
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar elemento de seguridad: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return elemento;
        }

        public bool AgregarElementoDeSeguridad(Entidades.ElementoDeSeguridad elemento)
        {
            try
            {
                AbriConexion();

                // Agregar a la tabla Producto

                string queryProducto = "INSERT INTO Producto (Codigo, Nombre, Descripcion, Precio, Stock, TipoProducto) " +
                                       "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @TipoProducto)";

                SqlCommand cmdProducto = new SqlCommand(queryProducto, connection);

                cmdProducto.Parameters.AddWithValue("@Codigo", elemento.Codigo);
                cmdProducto.Parameters.AddWithValue("@Nombre", elemento.Nombre);
                cmdProducto.Parameters.AddWithValue("@Descripcion", elemento.Descripcion);
                cmdProducto.Parameters.AddWithValue("@Precio", elemento.Precio);
                cmdProducto.Parameters.AddWithValue("@Stock", elemento.Stock);
                cmdProducto.Parameters.AddWithValue("@TipoProducto", "ElementoDeSeguridad");

                cmdProducto.ExecuteNonQuery();

                string queryElemento = "INSERT INTO EquipoDeSeguridad (Codigo, Talle, Peso, TipoEquipo, Normativa) " +
                                       "VALUES (@Codigo, @Talle, @Peso, @TipoEquipo, @Normativa)";

                SqlCommand cmdElemento = new SqlCommand(queryElemento, connection);
                cmdElemento.Parameters.AddWithValue("@Codigo", elemento.Codigo);
                cmdElemento.Parameters.AddWithValue("@Talle", elemento.Talle);
                cmdElemento.Parameters.AddWithValue("@Peso", elemento.Peso);
                cmdElemento.Parameters.AddWithValue("@TipoEquipo", elemento.TipoEquipo);
                cmdElemento.Parameters.AddWithValue("@Normativa", elemento.Normativa);

                cmdElemento.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar elemento de seguridad: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool ModificarElemento(Entidades.ElementoDeSeguridad elemento)
        {
            try
            {
                AbriConexion();

                // Actualizar en la tabla Producto
                string queryProducto = "UPDATE Producto SET " +
                                       "TipoProducto = @TipoProducto " +
                                       "WHERE Codigo = @Codigo";

                SqlCommand cmdProducto = new SqlCommand(queryProducto, connection);
                cmdProducto.Parameters.AddWithValue("@TipoProducto", "ElementoDeSeguridad");
                cmdProducto.Parameters.AddWithValue("@Codigo", elemento.Codigo);

                cmdProducto.ExecuteNonQuery();

                // Actualizar en la tabla ElementoDeSeguridad
                string queryElemento = "UPDATE EquipoDeSeguridad SET " +
                                       "Talle = @Talle, " +
                                       "Peso = @Peso, " +
                                       "TipoEquipo = @TipoEquipo, " +
                                       "Normativa = @Normativa " +
                                       "WHERE Codigo = @Codigo";

                SqlCommand cmdElemento = new SqlCommand(queryElemento, connection);
                cmdElemento.Parameters.AddWithValue("@Talle", elemento.Talle);
                cmdElemento.Parameters.AddWithValue("@Peso", elemento.Peso);
                cmdElemento.Parameters.AddWithValue("@TipoEquipo", elemento.TipoEquipo);
                cmdElemento.Parameters.AddWithValue("@Normativa", elemento.Normativa);
                cmdElemento.Parameters.AddWithValue("@Codigo", elemento.Codigo);

                int filasAfectadasElemento = cmdElemento.ExecuteNonQuery();

                return filasAfectadasElemento > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar elemento de seguridad: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

    }
}  
