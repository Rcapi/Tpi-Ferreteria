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
    public partial class ABMHerramientaDeMano : Form
    {
        private string codigoProducto;

        public ABMHerramientaDeMano(string codigo)
        {
            InitializeComponent();
            codigoProducto = codigo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {




        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Seguro que desea eliminar la herramienta De mano?", "Confirmar Eliminación", MessageBoxButtons.YesNo);

            if (confirmacion == DialogResult.Yes)
            {

                bool resultado = Negocio.HerramientaManual.EliminarHerramienta(codigoProducto);


                if (resultado)
                {
                    MessageBox.Show("Herramienta eléctrica eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Error al eliminar la herramienta eléctrica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}

