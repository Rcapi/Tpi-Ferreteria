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
    public partial class ActElementoDeSujecion : Form
    {
        public ActElementoDeSujecion()
        {
            InitializeComponent();
        }

        private void ActElementoDeSujecion_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar el código
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingrese un Codigo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar el nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar la descripción
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar el precio
            if (!float.TryParse(txtPrecio.Text, out float precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un valor de precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar el stock
            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Ingrese un valor de stock válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar el tipo de elemento
            if (string.IsNullOrWhiteSpace(txtTipoElemento.Text))
            {
                MessageBox.Show("Ingrese un tipo de elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar la longitud
            if (!int.TryParse(txtLongitud.Text, out int longitud) || longitud < 0)
            {
                MessageBox.Show("Ingrese un valor de longitud válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar la capacidad
            if (!int.TryParse(txtCapacidad.Text, out int capacidad) || capacidad < 0)
            {
                MessageBox.Show("Ingrese un valor de capacidad válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            Entidades.ElementoDeSujecion elementoExistente = new Entidades.ElementoDeSujecion(
                txtCodigo.Text,
                txtNombre.Text,
                txtDescripcion.Text,
                precio,
                stock,
                txtTipoElemento.Text,
                longitud,
                capacidad
            );

       
            bool exito = Negocio.ElementoDeSujecion.Agregar(elementoExistente);

            if (exito)
            {
                MessageBox.Show("Elemento de sujeción guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al guardar el elemento de sujeción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
