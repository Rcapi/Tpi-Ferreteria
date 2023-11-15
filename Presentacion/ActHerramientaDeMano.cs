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
    public partial class ActHerramientaDeMano : Form
    {
        public ActHerramientaDeMano()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {  // Validar el código
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
            // Validar el modelo
            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MostrarError("Ingrese un modelo válido.");
                return;
            }

            // Validar el tipo de herramienta
            if (string.IsNullOrWhiteSpace(txtTipoHerramienta.Text))
            {
                MostrarError("Ingrese un tipo de herramienta válido.");
                return;
            }

     
            
            Entidades.HerramientaDeMano herramienta = new Entidades.HerramientaDeMano(
                   txtCodigo.Text,
                   txtNombre.Text,
                   txtDescripcion.Text,
                   precio,
                   stock,
                   txtModelo.Text,
                   txtTipoHerramienta.Text
                   
               );


            bool exito = Negocio.HerramientaManual.Agregar(herramienta); 

            if (exito)
            {
                MostrarMensaje("Herramienta de mano guardada exitosamente.", MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MostrarError("Error al guardar la Herramienta de mano.");
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
