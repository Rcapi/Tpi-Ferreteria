namespace Presentacion
{
    partial class Venta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            radbtnIngresos = new RadioButton();
            radbtnCantidadPorMes = new RadioButton();
            btnImprimir = new Button();
            SuspendLayout();
            // 
            // radbtnIngresos
            // 
            radbtnIngresos.AutoSize = true;
            radbtnIngresos.Location = new Point(663, 26);
            radbtnIngresos.Name = "radbtnIngresos";
            radbtnIngresos.Size = new Size(143, 24);
            radbtnIngresos.TabIndex = 0;
            radbtnIngresos.TabStop = true;
            radbtnIngresos.Text = "Ingresos por mes\r\n";
            radbtnIngresos.UseVisualStyleBackColor = true;
            radbtnIngresos.CheckedChanged += radbtnIngresos_CheckedChanged;
            // 
            // radbtnCantidadPorMes
            // 
            radbtnCantidadPorMes.AutoSize = true;
            radbtnCantidadPorMes.Location = new Point(663, 56);
            radbtnCantidadPorMes.Name = "radbtnCantidadPorMes";
            radbtnCantidadPorMes.Size = new Size(131, 24);
            radbtnCantidadPorMes.TabIndex = 1;
            radbtnCantidadPorMes.TabStop = true;
            radbtnCantidadPorMes.Text = "Ventas por mes";
            radbtnCantidadPorMes.UseVisualStyleBackColor = true;
            radbtnCantidadPorMes.CheckedChanged += radbtnCantidadPorMes_CheckedChanged;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(663, 394);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(94, 29);
            btnImprimir.TabIndex = 2;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // Venta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 447);
            Controls.Add(btnImprimir);
            Controls.Add(radbtnCantidadPorMes);
            Controls.Add(radbtnIngresos);
            Name = "Venta";
            Text = "Venta";
            Load += Venta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radbtnIngresos;
        private RadioButton radbtnCantidadPorMes;
        private Button btnImprimir;
    }
}