using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosMaterialesDeConstruccion : Base
    {
        public List<Entidades.MaterialDeConstruccion> TraerTodosMaterialesDeConstruccion()
        {
            List<Entidades.MaterialDeConstruccion> materialesDeConstruccion = new List<Entidades.MaterialDeConstruccion>();

            try
            {
                AbriConexion();

                string query = "SELECT P.Codigo, P.Nombre, P.Descripcion, P.Precio, P.Stock, M.Marca, M.Medidas, M.TipoMaterial " +
                               "FROM Producto P " +
                               "INNER JOIN MaterialDeConstruccion M ON P.Codigo = M.Codigo";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Entidades.MaterialDeConstruccion material = new Entidades.MaterialDeConstruccion
                            (
                                reader["Codigo"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                (float)Convert.ToDouble(reader["Precio"]),
                                Convert.ToInt32(reader["Stock"]),
                                reader["Marca"].ToString(),
                                reader["Medidas"].ToString(),
                                reader["TipoMaterial"].ToString()
                            );

                            materialesDeConstruccion.Add(material);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al traer todos los materiales de construcción: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return materialesDeConstruccion;
        }

        public bool ModificarMaterialesDeConstruccion(Entidades.MaterialDeConstruccion material)
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
                    cmdProducto.Parameters.AddWithValue("@Descripcion", material.Descripcion);
                    cmdProducto.Parameters.AddWithValue("@Nombre", material.Nombre);
                    cmdProducto.Parameters.AddWithValue("@Precio", material.Precio);
                    cmdProducto.Parameters.AddWithValue("@Stock", material.Stock);
                    cmdProducto.Parameters.AddWithValue("@Codigo", material.Codigo);

                    int filasAfectadasProducto = cmdProducto.ExecuteNonQuery();

                    string queryMaterialesDeConstruccion = "UPDATE MaterialDeConstruccion SET " +
                                                           "Marca = @Marca, " +
                                                           "Medidas = @Medidas, " +
                                                           "TipoMaterial = @TipoMaterial " +
                                                           "WHERE Codigo = @Codigo";

                    using (SqlCommand cmdMaterialesDeConstruccion = new SqlCommand(queryMaterialesDeConstruccion, connection))
                    {
                        cmdMaterialesDeConstruccion.Parameters.AddWithValue("@Marca", material.Marca);
                        cmdMaterialesDeConstruccion.Parameters.AddWithValue("@Medidas", material.Medidas);
                        cmdMaterialesDeConstruccion.Parameters.AddWithValue("@TipoMaterial", material.TipoMaterial);
                        cmdMaterialesDeConstruccion.Parameters.AddWithValue("@Codigo", material.Codigo);

                        int filasAfectadasMaterialesDeConstruccion = cmdMaterialesDeConstruccion.ExecuteNonQuery();

                        return filasAfectadasProducto > 0 && filasAfectadasMaterialesDeConstruccion > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar material de construcción: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool EliminarMaterialesDeConstruccion(string codigo)
        {
            try
            {
                AbriConexion();

                string queryElemento = "DELETE FROM MaterialDeConstruccion WHERE Codigo = @Codigo";
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

        public Entidades.MaterialDeConstruccion TraerMaterialesDeConstruccionPorCodigo(string codigo)
        {
            Entidades.MaterialDeConstruccion material = null;

            try
            {
                AbriConexion();

                string query = "SELECT P.Codigo, P.Nombre, P.Descripcion, P.Precio, P.Stock, M.Marca, M.Medidas, M.TipoMaterial " +
                               "FROM Producto P " +
                               "INNER JOIN MaterialDeConstruccion M ON P.Codigo = M.Codigo " +
                               "WHERE P.Codigo = @Codigo";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            material = new Entidades.MaterialDeConstruccion
                            (
                                reader["Codigo"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                (float)Convert.ToDouble(reader["Precio"]),
                                Convert.ToInt32(reader["Stock"]),
                                reader["Marca"].ToString(),
                                reader["Medidas"].ToString(),
                                reader["TipoMaterial"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar material de construcción: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return material;
        }
        public bool AgregarMaterialesDeConstruccion(Entidades.MaterialDeConstruccion material)
        {
            try
            {
                AbriConexion();

                // Agregar a la tabla Producto
                string queryProducto = "INSERT INTO Producto (Codigo, Nombre, Descripcion, Precio, Stock, TipoProducto) " +
                                       "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @TipoProducto)";

                SqlCommand cmdProducto = new SqlCommand(queryProducto, connection);

                cmdProducto.Parameters.AddWithValue("@Codigo", material.Codigo);
                cmdProducto.Parameters.AddWithValue("@Nombre", material.Nombre);
                cmdProducto.Parameters.AddWithValue("@Descripcion", material.Descripcion);
                cmdProducto.Parameters.AddWithValue("@Precio", material.Precio);
                cmdProducto.Parameters.AddWithValue("@Stock", material.Stock);
                cmdProducto.Parameters.AddWithValue("@TipoProducto", "MaterialDeConstruccion");

                cmdProducto.ExecuteNonQuery();

                // Agregar a la tabla MaterialDeConstruccion
                string queryMaterial = "INSERT INTO MaterialDeConstruccion (Codigo, Marca, Medidas, TipoMaterial) " +
                                       "VALUES (@Codigo, @Marca, @Medidas, @TipoMaterial)";

                SqlCommand cmdMaterial = new SqlCommand(queryMaterial, connection);

                cmdMaterial.Parameters.AddWithValue("@Codigo", material.Codigo);
                cmdMaterial.Parameters.AddWithValue("@Marca", material.Marca);
                cmdMaterial.Parameters.AddWithValue("@Medidas", material.Medidas);
                cmdMaterial.Parameters.AddWithValue("@TipoMaterial", material.TipoMaterial);

                cmdMaterial.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar material de construcción: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }  

}