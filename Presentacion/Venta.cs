using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Entidades;

namespace Presentacion
{
    public partial class Venta : Form
    {
        private Chart chart1;

        public Venta()
        {
            InitializeComponent();

            
            chart1 = new Chart();
            chart1.Size = new System.Drawing.Size(600, 400); 
          

            ChartArea chartArea = new ChartArea();

            chart1.ChartAreas.Add(chartArea);

            Series series = new Series("Ventas");
            series.ChartType = SeriesChartType.Column; 

            
            chart1.Series.Add(series);

            
            chartArea.AxisX.Title = "Meses";
            chartArea.AxisY.Title = "Ventas";

          
            this.Controls.Add(chart1);
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            // Carga los datos al inicio
            CargarDatos();
        }

        private void radbtnIngresos_CheckedChanged(object sender, EventArgs e)
        {
            // Carga los datos al cambiar la selección del botón
            CargarDatos();
        }

        private void radbtnCantidadPorMes_CheckedChanged(object sender, EventArgs e)
        {
            // Carga los datos al cambiar la selección del botón
            CargarDatos();
        }

        private void CargarDatos()
        {
            
            List<DataPoint> puntosVentas = new List<DataPoint>();

            List<Ventas> ventas = Negocio.Venta.TraerTodasLasVentas();

            // Agrupa las ventas por mes y calcula la suma o la cantidad de cada mes
            var ventasPorMes = ventas
                .GroupBy(v => v.FechaHora.Month)
                .OrderBy(g => g.Key); // Ordena por el número de mes

            // Limpia los puntos de la serie antes de agregar nuevos
            chart1.Series["Ventas"].Points.Clear();

            // Itera sobre las ventas agrupadas y agrega puntos al gráfico
            foreach (var grupo in ventasPorMes)
            {
                int mes = grupo.Key;

                double valor;

                if (radbtnIngresos.Checked)
                {
                    valor = (double)grupo.Sum(v => (double)v.Total);

                    
                    chart1.ChartAreas[0].AxisY.Minimum = 1;
                    chart1.ChartAreas[0].AxisY.Maximum = 10000;
                }
                else 
                {
                    valor = grupo.Count();

                    
                    chart1.ChartAreas[0].AxisY.Minimum = 1;
                    chart1.ChartAreas[0].AxisY.Maximum = 10;
                }

                chart1.Series["Ventas"].Points.AddXY(MesAMesString(mes), valor);
            }
        }


        private string MesAMesString(int mes)
        {
            switch (mes)
            {
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                case 7: return "Julio";
                case 8: return "Agosto";
                case 9: return "Septiembre";
                case 10: return "Octubre";
                case 11: return "Noviembre";
                case 12: return "Diciembre";
                default: return "";
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Abre el cuadro de diálogo de impresión
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Configura el documento para impresión
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += new PrintPageEventHandler((s, ev) => ImprimirGrafico(s, ev, radbtnIngresos.Checked));
                printDocument.Print();
            }
        }

        private void ImprimirGrafico(object sender, PrintPageEventArgs e, bool esIngreso)
        {
            // Obtiene la imagen del gráfico
            Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
            chart1.DrawToBitmap(bmp, new Rectangle(0, 0, chart1.Width, chart1.Height));

            // Dibuja la imagen en la página de impresión
            e.Graphics.DrawImage(bmp, e.MarginBounds);

            // Agrega un encabezado indicando el tipo de impresión
            string tipoImpresion = esIngreso ? "Ingresos por mes" : "Ventas por mes";
            Font font = new Font("Arial", 12);
            e.Graphics.DrawString(tipoImpresion, font, Brushes.Black, new PointF(e.MarginBounds.Left, e.MarginBounds.Top - 40));
        }
    }
}



