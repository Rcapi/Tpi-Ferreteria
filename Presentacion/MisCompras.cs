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
    public partial class MisCompras : Form
    {
        private string dni; // Agrega un campo para almacenar el DNI

        public MisCompras(string dni)
        {
            InitializeComponent();
            this.dni = dni; // Almacena el DNI pasado como parámetro
        }

        private void MisCompras_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0; // Establece la primera opción como predeterminada
            CargarVentas();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void CargarVentas()
        {
            List<Ventas> ventas = Negocio.Venta.TraerTodasLasVentas();

          
            ventas = ventas.Where(v => v.DniCliente == dni).ToList();

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

            dataGridCompras.DataSource = ventas;
        }
    }


}
