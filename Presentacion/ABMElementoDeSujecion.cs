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
    public partial class ABMElementoDeSujecion : Form
    {

        
        public ABMElementoDeSujecion(string codigo)
        {
            InitializeComponent();
            txtCodigo.Text = codigo;
            Entidades.ElementoDeSujecion elementoDeSujecion = Negocio.ElementoDeSujecion.TraerElementoPorCodigo(codigo);
            if (elementoDeSujecion != null)
            {
                txtNombre.Text = elementoDeSujecion.Nombre;
                txtDescripcion.Text = elementoDeSujecion.Descripcion;
                txtPrecio.Text = elementoDeSujecion.Precio.ToString();
                txtStock.Text = elementoDeSujecion.Stock.ToString();
                txtCapacidad.Text = elementoDeSujecion.Capacidad.ToString();    
                txtLongitud.Text = elementoDeSujecion.Longitud.ToString();
                txtTipoElemento.Text = elementoDeSujecion.TipoElemento.ToString(); 
              
            }
            else
            {

                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;

           
            Entidades.ElementoDeSujecion elementoExistente = Negocio.ElementoDeSujecion.TraerElementoPorCodigo(codigo);

           
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

             
                elementoExistente.TipoElemento = txtTipoElemento.Text;

            
                if (int.TryParse(txtLongitud.Text, out int longitud))
                {
                    elementoExistente.Longitud = longitud;
                }
                else
                {
                    MessageBox.Show("Ingrese un valor de longitud válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (int.TryParse(txtCapacidad.Text, out int capacidad))
                {
                    elementoExistente.Capacidad = capacidad;
                }
                else
                {
                    MessageBox.Show("Ingrese un valor de capacidad válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool exito = Negocio.ElementoDeSujecion.ModificarElemento(elementoExistente);

                if (exito)
                {
                    MessageBox.Show("Elemento de sujeción guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar el elemento de sujeción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Elemento de sujeción no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

  

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool resultado = Negocio.ElementoDeSujecion.EliminarElemento(txtCodigo.Text);

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
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }

        }
    }
}
