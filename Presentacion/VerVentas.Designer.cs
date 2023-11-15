namespace Presentacion
{
    partial class VerVentas
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
            menuStrip1 = new MenuStrip();
            volverToolStripMenuItem = new ToolStripMenuItem();
            dataGridVentas = new DataGridView();
            txtDni = new TextBox();
            lblDni = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            btnBuscar = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridVentas).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { volverToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // volverToolStripMenuItem
            // 
            volverToolStripMenuItem.Name = "volverToolStripMenuItem";
            volverToolStripMenuItem.Size = new Size(64, 24);
            volverToolStripMenuItem.Text = "Volver";
            volverToolStripMenuItem.Click += volverToolStripMenuItem_Click;
            // 
            // dataGridVentas
            // 
            dataGridVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridVentas.Location = new Point(12, 97);
            dataGridVentas.Name = "dataGridVentas";
            dataGridVentas.RowHeadersWidth = 51;
            dataGridVentas.RowTemplate.Height = 29;
            dataGridVentas.Size = new Size(776, 318);
            dataGridVentas.TabIndex = 1;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(72, 60);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(125, 27);
            txtDni.TabIndex = 2;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(24, 64);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(42, 20);
            lblDni.TabIndex = 3;
            lblDni.Text = "DNI: ";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "De mayor a menor venta", "De menor a mayor venta ", "Mas Reciente", "Mas Antiguo" });
            comboBox1.Location = new Point(637, 58);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(582, 61);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 5;
            label1.Text = "Orden";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(214, 58);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // VerVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBuscar);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(lblDni);
            Controls.Add(txtDni);
            Controls.Add(dataGridVentas);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "VerVentas";
            Text = "VerVentas";
            Load += VerVentas_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem volverToolStripMenuItem;
        private DataGridView dataGridVentas;
        private TextBox txtDni;
        private Label lblDni;
        private ComboBox comboBox1;
        private Label label1;
        private Button btnBuscar;
    }
}