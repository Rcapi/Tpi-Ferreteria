using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class VerVentas : Form
    {
        public VerVentas()
        {
            InitializeComponent();
        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerVentas_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0; 
            CargarVentas();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void CargarVentas()
        {
            
            List<Ventas> ventas = Negocio.Venta.TraerTodasLasVentas();

            
            switch (comboBox1.SelectedItem.ToString())
            {
                case "De mayor a menor venta":
                    ventas = ventas.OrderByDescending(v => v.Total).ToList();
                    break;
                case "De menor a mayor venta":
                    ventas = ventas.OrderBy(v => v.Total).ToList();
                    break;
                case "Mas Reciente":
                    ventas = ventas.OrderByDescending(v => v.FechaHora).ToList();
                    break;
                case "Mas Antiguo":
                    ventas = ventas.OrderBy(v => v.FechaHora).ToList();
                    break;
            }

            
            dataGridVentas.DataSource = ventas;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text;

           
            List<Ventas> ventas = Negocio.Venta.TraerTodasLasVentas();

           
            if (!string.IsNullOrEmpty(dni))
            {
                ventas = ventas.Where(v => v.DniCliente == dni).ToList();
            }

            
            dataGridVentas.DataSource = ventas;
        }

    }
}

