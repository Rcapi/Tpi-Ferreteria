using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DatosUsuario : Base
    {
        public List<Usuario> BuscarTodosEmpleados()
        {
            List<Usuario> empleados = new List<Usuario>();

            try
            {
                AbriConexion();

                string query = "SELECT * FROM Usuario WHERE Rol = 'Empleado'";
                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario empleado = new Usuario
                        {
                            Dni = reader["Dni"].ToString(),
                            Clave = reader["Clave"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Email = reader["Email"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Ciudad = reader["Ciudad"].ToString(),
                            Rol = reader["Rol"].ToString()
                        };

                        empleados.Add(empleado);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar empleados: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return empleados;
        }

        public List<Usuario> BuscarTodosClientes()
        {
            List<Usuario> clientes = new List<Usuario>();

            try
            {
                AbriConexion();

                string query = "SELECT * FROM Usuario WHERE Rol = 'Cliente'";
                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario cliente = new Usuario
                        {
                            Dni = reader["Dni"].ToString(),
                            Clave = reader["Clave"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Email = reader["Email"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Ciudad = reader["Ciudad"].ToString(),
                            Rol = reader["Rol"].ToString()
                        };

                        clientes.Add(cliente);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar clientes: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return clientes;
        }

        public List<Usuario> BuscarUsuariosPorNombre(string nombre)
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                AbriConexion();

                string query = "SELECT * FROM Usuario WHERE Nombre = @Nombre";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            Dni = reader["Dni"].ToString(),
                            Clave = reader["Clave"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Email = reader["Email"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Ciudad = reader["Ciudad"].ToString(),
                            Rol = reader["Rol"].ToString()
                        };

                        usuarios.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar usuarios por nombre: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return usuarios;
        }
        public Usuario BuscarUsuarioPorDni(string dni)
        {
            Usuario usuario = null;

            try
            {
                AbriConexion();

                string query = "SELECT * FROM Usuario WHERE Dni = @Dni";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Dni", dni);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            Dni = reader["Dni"].ToString(),
                            Clave = reader["Clave"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Email = reader["Email"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Ciudad = reader["Ciudad"].ToString(),
                            Rol = reader["Rol"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar usuario: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return usuario;
        }

        public void EliminarUsuarioPorDni(string dni)
        {
            try
            {
                AbriConexion();

                string query = "DELETE FROM Usuario WHERE Dni = @Dni";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Dni", dni);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar usuario: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public void AgregarUsuario(Usuario usuario)
        {
            try
            {
                AbriConexion();

                string query = "INSERT INTO Usuario (Dni, Clave, Nombre, Apellido, Email, Telefono, Direccion, Ciudad, Rol) " +
                               "VALUES (@Dni, @Clave, @Nombre, @Apellido, @Email, @Telefono, @Direccion, @Ciudad, @Rol)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Dni", usuario.Dni);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@Ciudad", usuario.Ciudad);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar usuario: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

        }
        public void ActualizarUsuario(Usuario usuario)
        {
            try
            {
                AbriConexion();

                string query = "UPDATE Usuario SET Clave = @Clave, Nombre = @Nombre, Apellido = @Apellido, " +
                               "Email = @Email, Telefono = @Telefono, Direccion = @Direccion, Ciudad = @Ciudad " +
                               "WHERE Dni = @Dni";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Dni", usuario.Dni);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@Ciudad", usuario.Ciudad);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar usuario: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

    }
}
