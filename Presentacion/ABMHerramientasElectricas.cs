using System;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class ABMHerramientasElectricas : Form
    {


        public ABMHerramientasElectricas(string codigo)
        {
            try
            {
                InitializeComponent();

                // Verificar si el código se pasa correctamente
                if (string.IsNullOrWhiteSpace(codigo))
                {
                    Console.WriteLine("Error: El código proporcionado es inválido.");
                    MessageBox.Show("Código de herramienta inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtCodigo.Text = codigo;
                Entidades.HerramientaElectrica herramientaElectrica = Negocio.HerramientaElectrica.TraerHerramientaPorCodigo(txtCodigo.Text);

                if (herramientaElectrica != null)
                {
                    // Asignar valores a los controles
                    txtNombre.Text = herramientaElectrica.Nombre;
                    txtDescripcion.Text = herramientaElectrica.Descripcion;
                    txtPrecio.Text = herramientaElectrica.Precio.ToString();
                    txtStock.Text = herramientaElectrica.Stock.ToString();
                    txtModelo.Text = herramientaElectrica.Modelo;
                    txtTipo.Text = herramientaElectrica.TipoHerramienta;
                    txtPotencia.Text = herramientaElectrica.Potencia;
                }
                else
                {
                    Console.WriteLine("Error: No se encontró ninguna herramienta con el código proporcionado.");
                    MessageBox.Show("Herramienta no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el constructor de ABMHerramientasElectricas: " + ex.Message);
                MessageBox.Show("Error inesperado. Consulte los registros para obtener más información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


    

    private void ABMHerramientasElectricas_Load(object sender, EventArgs e)
        {
          
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) ||
                string.IsNullOrWhiteSpace(txtModelo.Text) ||
                string.IsNullOrWhiteSpace(txtPotencia.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text)) 
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar la herramienta eléctrica.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Entidades.HerramientaElectrica herramientaElectrica = new Entidades.HerramientaElectrica
            (
                txtCodigo.Text,
                txtNombre.Text,
                txtDescripcion.Text,
                float.Parse(txtPrecio.Text),
                int.Parse(txtStock.Text),
                txtModelo.Text,
                txtTipo.Text,
                txtPotencia.Text
             );

             Negocio.HerramientaElectrica.ModificarHerramienta(herramientaElectrica);

            
             MessageBox.Show("Herramienta eléctrica modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DialogResult confirmacion = MessageBox.Show("¿Seguro que desea eliminar el producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo);

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = Negocio.HerramientaElectrica.EliminarHerramienta(txtCodigo.Text);

                if (resultado)
                {
                    MessageBox.Show("Producto eliminado correctamente.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el producto.");
                }
            }
        }

        private void lblPrecio_Click(object sender, EventArgs e)
        {

        }
    }
}
