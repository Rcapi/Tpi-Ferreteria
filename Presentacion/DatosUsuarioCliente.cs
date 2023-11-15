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
    public partial class DatosUsuarioCliente : Form
    {
        public DatosUsuarioCliente(string Dni)
        {
            InitializeComponent();
            txtDni.Text = Dni;
            Entidades.Usuario cliente = Negocio.Usuario.BuscarPorDni(txtDni.Text);
            txtApellido.Text = cliente.Apellido;
            txtCiudad.Text = cliente.Ciudad;
            txtDireccion.Text = cliente.Direccion;
            txtMail.Text = cliente.Email;
            txtNombre.Text = cliente.Nombre;
            txtTelefono.Text = cliente.Telefono;
            txtClave.Text = cliente.Clave;
        }

        private void DatosUsuario_Load(object sender, EventArgs e)
        {


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarDatos modificarDatos = new ModificarDatos(txtDni.Text);
            modificarDatos.ShowDialog();
        }
    }
}
