using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class ModificarDatos : Form
    {
        public ModificarDatos(string dni)
        {
            InitializeComponent();
            txtDni.Text = dni;
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            Entidades.Usuario cliente = Negocio.Usuario.BuscarPorDni(txtDni.Text);
            txtApellido.Text = cliente.Apellido;
            txtCiudad.Text = cliente.Ciudad;
            txtDireccion.Text = cliente.Direccion;
            txtMail.Text = cliente.Email;
            txtNombre.Text = cliente.Nombre;
            txtTelefono.Text = cliente.Telefono;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {


            if (txtClave.Text != txtConfirmaClave.Text)
            {
                MessageBox.Show("La clave ingresada y la confirmación no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtDni.Text) || !EsNumero(txtDni.Text) || txtDni.Text.Length != 8)
            {
                MessageBox.Show("El campo DNI debe contener 8 dígitos numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) ||
                     string.IsNullOrEmpty(txtTelefono.Text) || !EsNumero(txtTelefono.Text) || txtTelefono.Text.Length < 8 || txtTelefono.Text.Length > 10)
            {
                MessageBox.Show("El campo Teléfono debe contener entre 8 y 10 dígitos numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtCiudad.Text))
            {
                MessageBox.Show("Los campos Dirección y Ciudad no pueden estar vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtMail.Text) || !EsFormatoEmailValido(txtMail.Text))
            {
                MessageBox.Show("El campo Email no tiene un formato válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Entidades.Usuario usuario = new Entidades.Usuario
                {
                    Dni = txtDni.Text,
                    Clave = txtClave.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtMail.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Ciudad = txtCiudad.Text
                };

                Negocio.Usuario.Actualizar(usuario);

                MessageBox.Show("El cliente se ha actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }        
            private bool EsNumero(string cadena)
            {
                    return int.TryParse(cadena, out _);
            }

              
            private bool EsFormatoEmailValido(string email)
            {
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(email);
                        return addr.Address == email;
                    }
                    catch
                    {
                        return false;
                    }
            }
    } 

}
    




