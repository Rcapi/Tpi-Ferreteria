using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosProducto : Base
    {
        public List<Producto> TraerTodos()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                AbriConexion();

                string query = "SELECT * FROM Producto";
                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Recuperando datos...");

                    
                        Console.WriteLine($"Codigo: {reader["Codigo"]}, Nombre: {reader["Nombre"]}, Descripcion: {reader["Descripcion"]}, Precio: {reader["Precio"]}, Stock: {reader["Stock"]}, TipoProducto: {reader["TipoProducto"]}");

                       Entidades.Producto producto = new Producto
                             (
                                 reader["Codigo"].ToString(),
                                 reader["Nombre"].ToString(),
                                 reader["Descripcion"].ToString(),
                                 (float)Convert.ToDouble(reader["Precio"]),
                                 Convert.ToInt32(reader["Stock"]),
                                 reader["TipoProducto"].ToString()
                             );


                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al traer todos los productos: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return productos;
        }



        public bool ModificarProducto(Producto producto)
        {
            try
            {
                AbriConexion();

                string query = "UPDATE Producto SET " +
                    "Nombre = @Nombre, " +
                    "Descripcion = @Descripcion, " +
                    "Precio = @Precio, " +
                    "Stock = @Stock " +
                    "TipoProducto = @TipoProducto" + 
                    "WHERE Codigo = @Codigo";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar producto: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool EliminarProducto(string codigo)
        {
            try
            {
                AbriConexion();

                string query = "DELETE FROM Producto WHERE Codigo = @Codigo";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar producto: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public Producto TraerProductoPorCodigo(string codigo)
        {
            Producto producto = null;

            try
            {
                AbriConexion();

                string query = "SELECT * FROM Producto WHERE Codigo = @Codigo";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new Producto
                            (
                                reader["Codigo"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                (float)Convert.ToDouble(reader["Precio"]),
                                Convert.ToInt32(reader["Stock"]),
                                reader["TipoProducto"].ToString() 
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar producto: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return producto;
        }

        public List<Entidades.Producto> TraerProductoPorNombre(string nombre)
        {
            List<Entidades.Producto> productos = new List<Entidades.Producto>();

            try
            {
                AbriConexion();

            
                string query = "SELECT * FROM Producto WHERE Nombre LIKE @Nombre";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto
                            (
                                reader["Codigo"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Descripcion"].ToString(),
                                (float)Convert.ToDouble(reader["Precio"]),
                                Convert.ToInt32(reader["Stock"]),
                                reader["TipoProducto"].ToString()
                            );

                            productos.Add(producto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar productos por nombre: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return productos;
        }



        public bool AgregarProducto(Producto producto)
        {
            try
            {
                AbriConexion();

                string query = string.Empty;
                SqlCommand cmd = null;

                switch (producto)
                {
                    case MaterialDeConstruccion material:
                        query = "INSERT INTO MaterialDeConstruccion (Codigo, Nombre, Descripcion, Precio, Stock, Marca, Medidas, TipoMaterial) " +
                                "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @Marca, @Medidas, @TipoMaterial)";
                        cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Marca", material.Marca);
                        cmd.Parameters.AddWithValue("@Medidas", material.Medidas);
                        cmd.Parameters.AddWithValue("@TipoMaterial", material.TipoMaterial);
                        break;

                    case HerramientaDeMano herramientaManual:
                        query = "INSERT INTO HerramientaManual (Codigo, Nombre, Descripcion, Precio, Stock, Modelo, Tipo) " +
                                "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @Modelo, @Tipo)";
                        cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Modelo", herramientaManual.Modelo);
                        cmd.Parameters.AddWithValue("@Tipo", herramientaManual.TipoHerramienta);
                        break;

                    case HerramientaElectrica herramientaElectrica:
                        query = "INSERT INTO HerramientaElectrica (Codigo, Nombre, Descripcion, Precio, Stock, Modelo, Potencia) " +
                                "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @Modelo, @Potencia)";
                        cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Modelo", herramientaElectrica.Modelo);
                        cmd.Parameters.AddWithValue("@Potencia", herramientaElectrica.Potencia);
                        break;

                    case ElementoDeSujecion elementoSujecion:
                        query = "INSERT INTO ElementoDeSujecion (Codigo, Nombre, Descripcion, Precio, Stock, Capacidad, Longitud, TipoElemento) " +
                                "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @Capacidad, @Longitud, @TipoElemento)";
                        cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Capacidad", elementoSujecion.Capacidad);
                        cmd.Parameters.AddWithValue("@Longitud", elementoSujecion.Longitud);
                        cmd.Parameters.AddWithValue("@TipoElemento", elementoSujecion.TipoElemento);
                        break;

                    case ElementoDeSeguridad equipoSeguridad:
                        query = "INSERT INTO EquipoDeSeguridad (Codigo, Nombre, Descripcion, Precio, Stock, Talle, Normativa, TipoEquipo) " +
                                "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @Talle, @Normativa, @TipoEquipo)";
                        cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Talle", equipoSeguridad.Talle);
                        cmd.Parameters.AddWithValue("@Normativa", equipoSeguridad.Normativa);
                        cmd.Parameters.AddWithValue("@TipoEquipo", equipoSeguridad.TipoEquipo);
                        break;

                    default:
                        return false;
                }

                if (string.IsNullOrWhiteSpace(producto.Codigo) ||
                    string.IsNullOrWhiteSpace(producto.Nombre) ||
                    string.IsNullOrWhiteSpace(producto.Descripcion) ||
                    string.IsNullOrWhiteSpace(producto.Precio.ToString()) ||
                    string.IsNullOrWhiteSpace(producto.Stock.ToString()))
                {
            
                    return false;
                }

                cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                cmd.Parameters.AddWithValue("@TipoProducto", producto.TipoProducto);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar producto: " + ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }



    }
}

