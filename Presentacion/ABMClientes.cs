
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Presentacion
{
    public partial class ABMClientes : Form
    {

        public ABMClientes()
        {
            InitializeComponent();
        }


        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ABMClientes_Load(object sender, EventArgs e)
        {
            dataGridViewClientes.DataSource = Negocio.Usuario.RecuperarClientes();



        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtBuscar.Text;
            List<Entidades.Usuario> usuariodni = new List<Entidades.Usuario> { Negocio.Usuario.BuscarPorDni(dni) };
            dataGridViewClientes.DataSource = usuariodni;

        }


        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            DatosUsuarioCliente datoscli = new DatosUsuarioCliente(txtBuscar.Text);
            datoscli.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Negocio.Usuario.EliminarPorDni(txtBuscar.Text);
            MessageBox.Show("Cliente Eliminado");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
