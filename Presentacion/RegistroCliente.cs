using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Presentacion
{
    public partial class RegistroCliente : Form
    {
        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            SeleccionarTipoUsuario seleccionarTipoUsuario = new SeleccionarTipoUsuario();
            seleccionarTipoUsuario.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validaciones existentes...
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
            else if (UsuarioExiste(txtDni.Text))
            {
                MessageBox.Show("Ya existe un usuario registrado con el mismo DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Resto del código para registrar el usuario...
                Entidades.Usuario usuario = new Entidades.Usuario();
                usuario.Apellido = txtApellido.Text;
                usuario.Dni = txtDni.Text;
                usuario.Email = txtMail.Text;
                usuario.Ciudad = txtCiudad.Text;
                usuario.Direccion = txtDireccion.Text;
                usuario.Clave = txtClave.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Rol = "Cliente";
                usuario.Telefono = txtTelefono.Text;

                Negocio.Usuario.AgregarUno(usuario);

                MessageBox.Show("El Cliente se ha registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool UsuarioExiste(string dni)
        {
            Entidades.Usuario usuarioExistente = Negocio.Usuario.BuscarPorDni(dni);
            return usuarioExistente != null;
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

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }







    }
}

