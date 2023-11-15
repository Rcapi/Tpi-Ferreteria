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
using Datos;

namespace Presentacion
{
    public partial class formMainAdmin : Form
    {
        public string NombreAdmin { get; set; }
        public string DniAdmin { get; set; }
        public formMainAdmin(string nombre, string dni)
        {
            InitializeComponent();
            NombreAdmin = nombre;
            DniAdmin = dni;
        }

        private void formMainAdmin_Load(object sender, EventArgs e)
        {
            lblBienvenido.Text = "Bienvenido, " + NombreAdmin;
        }

        private void linkLblCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            formIngreso formIngreso = new formIngreso();
            formIngreso.Show();
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            
            ABMClientes abmclientes = new ABMClientes();
            abmclientes.ShowDialog();
        }

        private void datosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
           
            ABMEmpleados abmempleados = new ABMEmpleados();
            abmempleados.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            
            ABMProductos aBMProductos = new ABMProductos(); 
            aBMProductos.ShowDialog();    
        }
    }
}
