using Entidades;
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
    public partial class ABMEmpleados : Form
    {
        public ABMEmpleados()
        {
            InitializeComponent();
        }



        private void dataGridViewEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }


        private void ABMEmpleados_Load(object sender, EventArgs e)
        {
            dataGridViewEmpleados.DataSource = Negocio.Usuario.RecuperarEmpleados();
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtBuscar.Text;
            List<Entidades.Usuario> usuariodni = new List<Entidades.Usuario> { Negocio.Usuario.BuscarPorDni(dni) };
            dataGridViewEmpleados.DataSource = usuariodni;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DatosUsuarioEmpleado datosemp = new DatosUsuarioEmpleado(txtBuscar.Text);
            datosemp.Show();
        }

        private void btnAgregarNuevo_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Negocio.Usuario.EliminarPorDni(txtBuscar.Text);
            MessageBox.Show("Empleado Eliminado");
        }
    }
}


