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
    public partial class Carrito : Form
    {
        public List<Entidades.Producto> ListaDeCarrito { get; set; }

        string dni;
        public Carrito(List<Entidades.Producto> carrito, string DniCliente)
        {
            InitializeComponent();
            dni = DniCliente;
            ListaDeCarrito = carrito;
        }

        private void Carrito_Load(object sender, EventArgs e)
        {
            dataGridProdCarrito.DataSource = ListaDeCarrito;

            float total = CalcularTotal();
            lblTotal.Text = "Total: $" + total.ToString("0.00");

            dataGridProdCarrito.Columns["Stock"].Visible = false;

            dataGridProdCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private float CalcularTotal()
        {
            float total = 0;

            foreach (var producto in ListaDeCarrito)
            {

                total += producto.Precio;
            }

            return total;
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                dataGridProdCarrito.DataSource = ListaDeCarrito;
                dataGridProdCarrito.Columns["Stock"].Visible = false;

                dataGridProdCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                string codigo = txtBuscar.Text;
                // No redefinas la variable ListaDeCarrito aquí, simplemente filtra la lista existente
                List<Entidades.Producto> productosEncontrados = ListaDeCarrito
                    .Where(p => p.Codigo == codigo)
                    .ToList();

                if (productosEncontrados.Count > 0)
                {
                    dataGridProdCarrito.DataSource = productosEncontrados;
                    dataGridProdCarrito.Columns["Stock"].Visible = false;

                    dataGridProdCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("No se encontraron productos con el código ingresado en el carrito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                string codigo = txtBuscar.Text;

                // Busca la primera instancia del producto en la lista por el código
                Entidades.Producto productoAEliminar = ListaDeCarrito.FirstOrDefault(p => p.Codigo == codigo);

                if (productoAEliminar != null)
                {
                    // Elimina la primera instancia del producto del carrito
                    ListaDeCarrito.Remove(productoAEliminar);

                    // Actualiza el DataGridView con la nueva lista
                    dataGridProdCarrito.DataSource = null;
                    dataGridProdCarrito.DataSource = ListaDeCarrito;

                    // Calcula y muestra el nuevo total
                    float total = CalcularTotal();
                    lblTotal.Text = "Total: $" + total.ToString("0.00");
                }
                else
                {
                    MessageBox.Show("El producto con el código ingresado no se encontró en el carrito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un código para buscar y eliminar un producto del carrito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      

     

        private void btnComprar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Compra com = new Compra(ListaDeCarrito, dni, CalcularTotal());
            com.ShowDialog();
        }
    }
}
