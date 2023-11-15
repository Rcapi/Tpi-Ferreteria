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
    public partial class formMainEmpleado : Form
    {
        public string NombreEmpleado { get; set; }
        public string DNI { get; set; }
        public formMainEmpleado(string nombre, string dni)
        {
            InitializeComponent();
            NombreEmpleado = nombre;
            DNI = dni;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void formMainEmpleado_Load(object sender, EventArgs e)
        {
            lblBienvenido.Text = "Bienvenido, " + NombreEmpleado;
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            formIngreso formIngreso = new formIngreso();
            formIngreso.Show();
            this.Close();
        }

        private void agregarEliminarModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMProductos aBMProductos = new ABMProductos();
            aBMProductos.Show();
        }

        private void agregarEliminarModificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ABMClientes abmClientes = new ABMClientes();
            abmClientes.Show();
        }

        private void modificarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosUsuarioEmpleado datosUsuarioEmpleado = new DatosUsuarioEmpleado(DNI);
            datosUsuarioEmpleado.ShowDialog();
        }



        private void graficosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Venta ventas = new Venta();
            ventas.ShowDialog();
        }

        private void verVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            VerVentas ver = new VerVentas();
            ver.ShowDialog();
        }
    }
}
