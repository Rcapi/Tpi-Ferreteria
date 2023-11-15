using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos; 



namespace Presentacion
{
    public partial class ABMElementoDeSeguridad : Form
    {
        public ABMElementoDeSeguridad(string codigo)
        {
            InitializeComponent();
            
            txtCodigo.Text = codigo;
            Entidades.ElementoDeSeguridad elementoExistente = Negocio.ElementoDeSeguridad.TraerElemento(txtCodigo.Text);

            if (elementoExistente != null)
            {
                txtNombre.Text = elementoExistente.Nombre;
                txtDescripcion.Text = elementoExistente.Descripcion;
                txtPrecio.Text = elementoExistente.Precio.ToString();
                txtStock.Text = elementoExistente.Stock.ToString();
                txtTalle.Text = elementoExistente.Talle;
                txtNormativa.Text = elementoExistente.Normativa;
                txtTipoEquipo.Text = elementoExistente.TipoEquipo;
                txtPeso.Text = elementoExistente.Peso.ToString();
            }
            else
            {
                MessageBox.Show("Elemento de seguridad no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
                
                string codigo = txtCodigo.Text;

             
                Entidades.ElementoDeSeguridad elementoExistente = Negocio.ElementoDeSeguridad.TraerElemento(codigo);

                
                if (elementoExistente != null)
                {
                   
                    elementoExistente.Nombre = txtNombre.Text;
                    elementoExistente.Descripcion = txtDescripcion.Text;

                    if (float.TryParse(txtPrecio.Text, out float precio))
                    {
                        elementoExistente.Precio = precio;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un valor de precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                
                    if (int.TryParse(txtStock.Text, out int stock))
                    {
                        elementoExistente.Stock = stock;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un valor de stock válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    elementoExistente.Talle = txtTalle.Text;
                    elementoExistente.Normativa = txtNormativa.Text;
                    elementoExistente.TipoEquipo = txtTipoEquipo.Text;

                   
                    if (float.TryParse(txtPeso.Text, out float peso))
                    {
                        elementoExistente.Peso = peso;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un valor de peso válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool exito = Negocio.ElementoDeSeguridad.ModificarElemento(elementoExistente);

                    if (exito)
                    {
                        MessageBox.Show("Elemento de seguridad guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el elemento de seguridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Elemento de seguridad no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Seguro que desea eliminar el producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo);

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = Negocio.ElementoDeSeguridad.EliminarElemento(txtCodigo.Text);

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


