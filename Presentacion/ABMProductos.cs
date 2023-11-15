using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Entidades;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Datos;

namespace Presentacion
{
    public partial class ABMProductos : Form
    {
        public ABMProductos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                List<Producto> todosLosProductos = new List<Producto>();

                todosLosProductos.AddRange(Negocio.ElementoDeSeguridad.TraerTodos());
                todosLosProductos.AddRange(Negocio.ElementoDeSujecion.TraerTodos());
                todosLosProductos.AddRange(Negocio.HerramientaElectrica.TraerTodos());
                todosLosProductos.AddRange(Negocio.HerramientaManual.TraerTodos());
                todosLosProductos.AddRange(Negocio.MaterialDeConstruccion.TraerTodos());

                dataGridProductos.DataSource = todosLosProductos;
            }
            else
            {

                string codigo = txtBuscar.Text;
                List<Entidades.Producto> productos = new List<Entidades.Producto>() { Negocio.Producto.BuscarPorCodigo(codigo) };
                dataGridProductos.DataSource = productos;
            }

        }



        private void ABMProductos_Load(object sender, EventArgs e)
        {
            List<Producto> todosLosProductos = new List<Producto>();

            todosLosProductos.AddRange(Negocio.ElementoDeSeguridad.TraerTodos());
            todosLosProductos.AddRange(Negocio.ElementoDeSujecion.TraerTodos());
            todosLosProductos.AddRange(Negocio.HerramientaElectrica.TraerTodos());
            todosLosProductos.AddRange(Negocio.HerramientaManual.TraerTodos());
            todosLosProductos.AddRange(Negocio.MaterialDeConstruccion.TraerTodos());

            dataGridProductos.DataSource = todosLosProductos;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string codigo = txtBuscar.Text;
            Negocio.Producto.EliminarPorCodigo(codigo);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string codigo = txtBuscar.Text;
            Entidades.Producto prod = Negocio.Producto.BuscarPorCodigo(codigo);

            if (prod != null)
            {
                string tipoHerramienta = prod.TipoProducto;

                switch (tipoHerramienta)
                {
                    case "HerramientaManual":
                        using (ABMHerramientaDeMano aBMHerramientaDeMano = new ABMHerramientaDeMano(codigo))
                        {
                            aBMHerramientaDeMano.ShowDialog();
                        }
                        break;

                    case "HerramientaElectrica":
                        using (ABMHerramientasElectricas aBMHerramientaElectrica = new ABMHerramientasElectricas(txtBuscar.Text))
                        {
                            aBMHerramientaElectrica.ShowDialog();
                        }
                        break;

                    case "ElementoDeSujecion":
                        using (ABMElementoDeSujecion aBMElementoDeSujecion = new ABMElementoDeSujecion(codigo))
                        {
                            aBMElementoDeSujecion.ShowDialog();
                        }
                        break;

                    case "ElementoDeSeguridad":
                        using (ABMElementoDeSeguridad aBMEquipoDeSeguridad = new ABMElementoDeSeguridad(codigo))
                        {
                            aBMEquipoDeSeguridad.ShowDialog();
                        }
                        break;

                    case "MaterialDeConstruccion":
                        using (ABMMaterialesDeConstruccion aBMMaterialDeConstruccion = new ABMMaterialesDeConstruccion(codigo))
                        {
                            aBMMaterialDeConstruccion.ShowDialog();
                        }
                        break;

                    default:
                        MessageBox.Show("Código incorrecto o no está definido su tipo.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Producto no encontrado.");
            }
        }

        private void comboAgregarProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcionSeleccionada = comboAgregarProd.SelectedItem.ToString();


            switch (opcionSeleccionada)
            {
                case "Herramienta De Mano":
                    ActHerramientaDeMano nuevaherramientamano = new ActHerramientaDeMano();
                    nuevaherramientamano.ShowDialog();
                    break;

                case "Herramienta Eléctrica":
                    ActHerramientaElectrica nuevaherramientaele = new ActHerramientaElectrica();
                    nuevaherramientaele.ShowDialog();
                    break;

                case "Elemento De Sujeción":
                    ActElementoDeSujecion nuevoEleSujecion = new ActElementoDeSujecion();
                    nuevoEleSujecion.ShowDialog();
                    break;

                case "Equipo De Seguridad":
                    ActElementoDeSeguridad nuevoEleSeguridad = new ActElementoDeSeguridad();
                    nuevoEleSeguridad.ShowDialog();
                    break;

                case "Material De Construccion":
                    ActMaterialDeConstruccion NuevoMaterialDeCons = new ActMaterialDeConstruccion();
                    NuevoMaterialDeCons.ShowDialog();
                    break;
            }
        }

        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
