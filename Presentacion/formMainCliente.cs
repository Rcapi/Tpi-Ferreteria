using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Entidades;
using Microsoft.VisualBasic;
using Negocio;

namespace Presentacion
{



    public partial class formMainCliente : Form
    {
        public string NombreCliente;
        public string DniCliente;
        private List<Entidades.Producto> carrito = new List<Entidades.Producto>();
        public formMainCliente(string nombre, string dni)
        {
            InitializeComponent();
            NombreCliente = nombre;
            DniCliente = dni;

        }

        private void lblBienvenido_Click(object sender, EventArgs e)
        {

        }


        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void formMainCliente_Load(object sender, EventArgs e)
        {
            lblBienvenido.Text = "Bienvenido, " + NombreCliente;
            listaOriginal = new List<Entidades.Producto>(Negocio.Producto.RecuperarProductos());
            listaActualBinding = new BindingList<Entidades.Producto>(listaOriginal);
            dataGridProductos.DataSource = listaActualBinding;
            comboBox2.SelectedIndex = 0;
            dataGridProductos.Columns["Stock"].Visible = false;


            dataGridProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            formIngreso formIngreso = new formIngreso();
            formIngreso.Show();
            this.Close();
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {

        }

        private void datosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DatosUsuarioCliente datosuser = new DatosUsuarioCliente(DniCliente);
            datosuser.Show();

        }

        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text;
            dataGridProductos.DataSource = Negocio.Producto.BuscarPorNombre(nombre);
        }


        private void btnAgregarAlCarrito_Click_1(object sender, EventArgs e)
        {
            string idprod = txtAgregar.Text;
            Entidades.Producto producto = Negocio.Producto.BuscarPorCodigo(idprod);

            if (producto != null)
            {

                int cantidad;
                if (int.TryParse(Interaction.InputBox("Ingrese la cantidad de productos:", "Cantidad", "1"), out cantidad))
                {

                    if (cantidad > 0)
                    {

                        if (cantidad <= producto.Stock)
                        {

                            for (int i = 0; i < cantidad; i++)
                            {
                                carrito.Add(producto);
                            }
                            MessageBox.Show("Producto(s) agregado(s) al carrito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("La cantidad ingresada supera el stock disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad debe ser mayor que 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se encontró un producto con el código ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnCarrito_Click_2(object sender, EventArgs e)
        {
            if (carrito.Any())
            {
                Carrito carritoform = new Carrito(carrito, DniCliente);
                carritoform.ShowDialog();
            }
            else
            {
                MessageBox.Show("El carrito está vacío.", "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private List<Entidades.Producto> listaOriginal;
        private BindingList<Entidades.Producto> listaActualBinding;




        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (listaActualBinding == null)
            {
                return;
            }


            if (comboBox2.SelectedItem.ToString().Contains("Precio"))
            {
                if (comboBox2.SelectedItem.ToString().Contains("+"))
                {
                    listaActualBinding = new BindingList<Entidades.Producto>(listaActualBinding.OrderBy(item => item.Precio).ToList());
                }
                else if (comboBox2.SelectedItem.ToString().Contains("-"))
                {
                    listaActualBinding = new BindingList<Entidades.Producto>(listaActualBinding.OrderByDescending(item => item.Precio).ToList());
                }
            }


            if (comboBox2.SelectedItem.ToString().Contains("A a Z"))
            {
                listaActualBinding = new BindingList<Entidades.Producto>(listaActualBinding.OrderBy(item => item.Nombre).ToList());
            }
            else if (comboBox2.SelectedItem.ToString().Contains("Z a A"))
            {
                listaActualBinding = new BindingList<Entidades.Producto>(listaActualBinding.OrderByDescending(item => item.Nombre).ToList());
            }

            dataGridProductos.DataSource = listaActualBinding;
        }

        private void verMisComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MisCompras compras = new MisCompras(DniCliente); 
            compras.Show(); 
        }
    }
}
