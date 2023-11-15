using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;  // Agregado para CultureInfo
using System.Linq;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Compra : Form
    {
        private List<Entidades.Producto> carrito;

        public Compra(List<Entidades.Producto> carrito, string Dni, float preciototal)
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
            lblTotal.Text = "TOTAL: " + preciototal;

            this.carrito = carrito;
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtMetodo.Text))
            {
                MessageBox.Show("Por favor, ingrese un método de pago válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                RegistrarVenta();
                printDocument1.Print();
                MessageBox.Show("La factura ha sido impresa correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void RegistrarVenta()
        {
            string dniCliente = txtDni.Text;

            // Corregir la conversión de la cadena a decimal
            decimal totalVenta = decimal.Parse(lblTotal.Text.Substring(7), CultureInfo.InvariantCulture);

            string metodoPago = txtMetodo.Text;

            Entidades.Ventas venta = new Entidades.Ventas
            {
                FechaHora = DateTime.Now,
                DniCliente = dniCliente,
                Total = totalVenta,
                MetodoDePago = metodoPago,
                Productos = carrito
            };

            Negocio.Venta.AgregarVenta(venta);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            Font font = new Font("Arial", 12);
            float yPos = 100;


            Dictionary<string, int> cantidadPorProducto = new Dictionary<string, int>();


            foreach (var producto in carrito)
            {
                if (cantidadPorProducto.ContainsKey(producto.Codigo))
                {
                    cantidadPorProducto[producto.Codigo]++;
                }
                else
                {
                    cantidadPorProducto.Add(producto.Codigo, 1);
                }
            }

            e.Graphics.DrawString("FACTURA", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, 100, yPos);
            yPos += 30;

            e.Graphics.DrawString($"Cliente: {txtNombre.Text} {txtApellido.Text}", font, Brushes.Black, 100, yPos);
            e.Graphics.DrawString($"DNI: {txtDni.Text}", font, Brushes.Black, 100, yPos + 20);
            e.Graphics.DrawString($"Dirección: {txtDireccion.Text}, {txtCiudad.Text}", font, Brushes.Black, 100, yPos + 40);
            e.Graphics.DrawString($"Email: {txtMail.Text}", font, Brushes.Black, 100, yPos + 60);
            e.Graphics.DrawString($"Teléfono: {txtTelefono.Text}", font, Brushes.Black, 100, yPos + 80);

            yPos += 120;

            // Encabezado de la tabla
            string[] columnas = { "Código", "Nombre", "Precio", "Cantidad" };
            float[] columnWidths = { 100, 200, 100, 100 };

            float xPosition = 100;

            for (int i = 0; i < columnas.Length; i++)
            {
                e.Graphics.DrawString(columnas[i], font, Brushes.Black, xPosition, yPos);
                xPosition += columnWidths[i];
            }

            yPos += 20;

            // Imprime los productos en formato de tabla
            foreach (var producto in cantidadPorProducto.Keys)
            {
                var productoEncontrado = carrito.Find(p => p.Codigo == producto);

                if (productoEncontrado != null)
                {
                    // Imprime cada atributo en su columna correspondiente
                    xPosition = 100;
                    e.Graphics.DrawString(productoEncontrado.Codigo, font, Brushes.Black, xPosition, yPos);
                    xPosition += columnWidths[0];
                    e.Graphics.DrawString(productoEncontrado.Nombre, font, Brushes.Black, xPosition, yPos);
                    xPosition += columnWidths[1];
                    e.Graphics.DrawString(productoEncontrado.Precio.ToString(), font, Brushes.Black, xPosition, yPos);
                    xPosition += columnWidths[2];
                    int cantidad = cantidadPorProducto[producto];
                    e.Graphics.DrawString(cantidad.ToString(), font, Brushes.Black, xPosition, yPos);

                    yPos += 20;
                }
            }

            string totalText = $"Total: {lblTotal.Text.Substring(7)}";
            SizeF totalSize = e.Graphics.MeasureString(totalText, font);
            e.Graphics.DrawString(totalText, font, Brushes.Black, e.PageBounds.Width - totalSize.Width - 50, e.PageBounds.Height - totalSize.Height - 50);
        }

        private void Compra_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = carrito; 
            dataGridView.Columns["Stock"].Visible = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

