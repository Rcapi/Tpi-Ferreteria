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

    public partial class ABMMaterialesDeConstruccion : Form
    {
        public ABMMaterialesDeConstruccion(string codigo)
        {
            InitializeComponent();

            txtCodigo.Text = codigo;
            Entidades.MaterialDeConstruccion productoExistente = Negocio.MaterialDeConstruccion.TraerMaterialPorCodigo(codigo);
            if (productoExistente != null)
            {
                
              
                txtNombre.Text = productoExistente.Nombre;
                txtDescripcion.Text = productoExistente.Descripcion;
                txtPrecio.Text = productoExistente.Precio.ToString();
                txtStock.Text = productoExistente.Stock.ToString();   
                txtMarca.Text = productoExistente.Marca;
                txtMedida.Text = productoExistente.Medidas;
            }
            else
            {
                
                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                this.Close();
            }
        }

      private void btnGuardarr_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;

            
            Entidades.MaterialDeConstruccion productoExistente = Negocio.MaterialDeConstruccion.TraerMaterialPorCodigo(codigo);

            
            if (productoExistente != null)
            {
               
                productoExistente.Nombre = txtNombre.Text;
                productoExistente.Descripcion = txtDescripcion.Text;

               
                if (float.TryParse(txtPrecio.Text, out float precio))
                {
                    productoExistente.Precio = precio;
                }
                else
                {
                    MessageBox.Show("Ingrese un valor de precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                if (int.TryParse(txtStock.Text, out int stock))
                {
                    productoExistente.Stock = stock;
                }
                else
                {
                    MessageBox.Show("Ingrese un valor de stock válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                productoExistente.Marca = txtMarca.Text;
                productoExistente.Medidas = txtMedida.Text;

                
                bool actualizado = Negocio.MaterialDeConstruccion.ModificarMaterial(productoExistente);

               
                if (actualizado)
                {
                    MessageBox.Show("Material de construcción actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el material de construcción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
              
                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       

        private void btnElminiar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Seguro que desea eliminar el producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo);

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = Negocio.MaterialDeConstruccion.EliminarMaterial(txtCodigo.Text);

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
    }




}
