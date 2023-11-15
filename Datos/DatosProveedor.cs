using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades; 

namespace Datos
{
    public class DatosProveedor : Base
    {
        public List<Entidades.Proveedores> TraerTodos()
        {
            List<Entidades.Proveedores> proveedores = new List<Entidades.Proveedores>();

            try
            {
                AbriConexion();

                string query = "SELECT * FROM Proveedor";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Entidades.Proveedores proveedor = new Entidades.Proveedores
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Ciudad = reader["Ciudad"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Email = reader["Email"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            };

                            proveedores.Add(proveedor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al traer todos los proveedores: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return proveedores;
        }

        public bool ModificarProveedor(Entidades.Proveedores proveedor)
        {
            try
            {
                AbriConexion();

                string query = "UPDATE Proveedor SET " +
                    "Ciudad = @Ciudad, " +
                    "Direccion = @Direccion, " +
                    "Email = @Email, " +
                    "Nombre = @Nombre, " +
                    "Telefono = @Telefono " +
                    "WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Ciudad", proveedor.Ciudad);
                    cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@ID", proveedor.ID);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar proveedor: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool EliminarProveedor(int id)
        {
            try
            {
                AbriConexion();

                string query = "DELETE FROM Proveedor WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar proveedor: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public Entidades.Proveedores TraerProveedorPorID(int id)
        {
            Entidades.Proveedores proveedor = null;

            try
            {
                AbriConexion();

                string query = "SELECT * FROM Proveedor WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            proveedor = new Entidades.Proveedores
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Ciudad = reader["Ciudad"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Email = reader["Email"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar proveedor por ID: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return proveedor;
        }
    }
}
