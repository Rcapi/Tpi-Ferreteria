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
    public partial class ActMaterialDeConstruccion : Form
    {
        public ActMaterialDeConstruccion()
        {
            InitializeComponent();
        }

        private void btnGuardarr_Click(object sender, EventArgs e)
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

                // Validar el tipo de material
                if (string.IsNullOrWhiteSpace(txtTipoMaterial.Text))
                {
                    MostrarError("Ingrese un tipo de Material válido.");
                    return;
                }

                // Validar el peso
                if (string.IsNullOrWhiteSpace(txtMedida.Text))
                {
                    MostrarError("Ingrese un valor de medida válido.");
                    return;
                }

                // Validar la marca
                if (string.IsNullOrWhiteSpace(txtMarca.Text))
                {
                    MostrarError("Ingrese una marca válida.");
                    return;
                }

                // Crear una nueva instancia de MaterialDeConstruccion
                Entidades.MaterialDeConstruccion productoExistente = new Entidades.MaterialDeConstruccion(
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtDescripcion.Text,
                    precio,
                    stock,
                    txtMarca.Text,
                    txtMedida.Text,
                    txtTipoMaterial.Text
                );

              
                bool exito = Negocio.MaterialDeConstruccion.Agregar(productoExistente);

                if (exito)
                {
                    MostrarMensaje("Material de construcción guardado exitosamente.", MessageBoxIcon.Information);
                    
                    this.Close();
                }
                else
                {
                    MostrarError("Error al guardar el Material de construcción.");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error inesperado: " + ex.ToString());
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


    


