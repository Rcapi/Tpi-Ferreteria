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
    public partial class ActElementoDeSeguridad : Form
    {
        public ActElementoDeSeguridad()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar el código
                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MostrarError("Ingrese un Codigo válido.");
                    return;
                }

                // Validar el nombre
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MostrarError("Ingrese un nombre válido.");
                    return;
                }

                // Validar la descripción
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MostrarError("Ingrese una descripción válida.");
                    return;
                }

                // Validar el precio
                if (!float.TryParse(txtPrecio.Text, out float precio) || precio < 0)
                {
                    MostrarError("Ingrese un valor de precio válido.");
                    return;
                }

                // Validar el stock
                if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
                {
                    MostrarError("Ingrese un valor de stock válido.");
                    return;
                }

                // Validar el tipo de elemento
                if (string.IsNullOrWhiteSpace(txtTipoEquipo.Text))
                {
                    MostrarError("Ingrese un tipo de elemento válido.");
                    return;
                }

              

                // Validar el tipo de equipo
                if (string.IsNullOrWhiteSpace(txtTipoEquipo.Text))
                {
                    MostrarError("Ingrese un tipo de equipo válido.");
                    return;
                }

                // Validar la normativa
                if (string.IsNullOrWhiteSpace(txtNormativa.Text))
                {
                    MostrarError("Ingrese una normativa válida.");
                    return;
                }

                // Validar el peso
                if (!float.TryParse(txtPeso.Text, out float peso) || peso < 0)
                {
                    MostrarError("Ingrese un valor de peso válido.");
                    return;
                }

                // Validar el talle
                if (string.IsNullOrWhiteSpace(txtTalle.Text))
                {
                    MostrarError("Ingrese un talle válido.");
                    return;
                }

             
                Entidades.ElementoDeSeguridad elementoExistente = new Entidades.ElementoDeSeguridad
              (
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtDescripcion.Text,
                    precio,
                    stock,
                    txtTalle.Text,
                    txtNormativa.Text,
                    txtTipoEquipo.Text,
                    peso
                 
               );

                // Intentar agregar el nuevo elemento
                 Negocio.ElementoDeSeguridad.Agregar(elementoExistente);

                
                    MostrarMensaje("equipo de Seguridad guardado exitosamente.", MessageBoxIcon.Information);
                    this.Close(); 
                
                
            }
            catch (Exception ex)
            {
                MostrarError("Error inesperado: " + ex.Message);
            }
        }

        private void MostrarMensaje(string mensaje, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, icono);
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}