using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class formIngreso : Form
    {
        public formIngreso()
        {
            InitializeComponent();
        }


        void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string clave = txtClave.Text;

            Datos.DatosUsuario datosUsuario = new Datos.DatosUsuario();

            try
            {
                Entidades.Usuario usuarioEncontrado = datosUsuario.BuscarUsuarioPorDni(usuario);

                if (usuarioEncontrado != null && usuarioEncontrado.Clave == clave)
                {
                    if (usuarioEncontrado.Rol == "Cliente")
                    {
                        this.Hide();
                        MessageBox.Show("¡Bienvenido, cliente!");
                        formMainCliente cliente = new formMainCliente(usuarioEncontrado.Nombre, usuarioEncontrado.Dni);  
                        cliente.ShowDialog();


                    }
                    else if (usuarioEncontrado.Rol == "Empleado")
                    {
                        this.Hide();
                        MessageBox.Show("¡Bienvenido, empleado!");
                        formMainEmpleado empleado = new formMainEmpleado(usuarioEncontrado.Nombre, usuarioEncontrado.Dni);
                        empleado.ShowDialog();
                    }
                    else
                    {
                        this.Hide();
                        MessageBox.Show("¡Bienvenido, admin!");
                        formMainAdmin admin = new formMainAdmin(usuarioEncontrado.Nombre, usuarioEncontrado.Dni);
                        admin.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
            }
            finally
            {
                datosUsuario.CerrarConexion();
            }
        }




        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLblRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); 
            SeleccionarTipoUsuario tipo = new SeleccionarTipoUsuario();
            tipo.ShowDialog(); 
            
        }
    }
}
