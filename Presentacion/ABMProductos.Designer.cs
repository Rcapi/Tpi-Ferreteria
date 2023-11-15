namespace Presentacion
{
    partial class ABMProductos
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
            btnActualizar = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            lblCod = new Label();
            comboAgregarProd = new ComboBox();
            lblProd = new Label();
            dataGridProductos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridProductos).BeginInit();
            SuspendLayout();
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(607, 40);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(136, 45);
            btnActualizar.TabIndex = 12;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(436, 40);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(136, 45);
            btnBuscar.TabIndex = 10;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(143, 49);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(235, 27);
            txtBuscar.TabIndex = 9;
            // 
            // lblCod
            // 
            lblCod.AutoSize = true;
            lblCod.Location = new Point(67, 52);
            lblCod.Name = "lblCod";
            lblCod.Size = new Size(61, 20);
            lblCod.TabIndex = 8;
            lblCod.Text = "Codigo:";
            // 
            // comboAgregarProd
            // 
            comboAgregarProd.FormattingEnabled = true;
            comboAgregarProd.Items.AddRange(new object[] { "Herramienta De Mano", "Herramienta Eléctrica", "Equipo De Seguridad", "Material De Construccion", "Elemento De Sujeción" });
            comboAgregarProd.Location = new Point(953, 52);
            comboAgregarProd.Name = "comboAgregarProd";
            comboAgregarProd.Size = new Size(151, 28);
            comboAgregarProd.TabIndex = 13;
            comboAgregarProd.SelectedIndexChanged += comboAgregarProd_SelectedIndexChanged;
            // 
            // lblProd
            // 
            lblProd.AutoSize = true;
            lblProd.Location = new Point(937, 29);
            lblProd.Name = "lblProd";
            lblProd.Size = new Size(184, 20);
            lblProd.TabIndex = 14;
            lblProd.Text = "Agregar nuevos productos";
            // 
            // dataGridProductos
            // 
            dataGridProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProductos.Location = new Point(25, 125);
            dataGridProductos.Name = "dataGridProductos";
            dataGridProductos.ReadOnly = true;
            dataGridProductos.RowHeadersWidth = 51;
            dataGridProductos.RowTemplate.Height = 29;
            dataGridProductos.Size = new Size(1137, 376);
            dataGridProductos.TabIndex = 15;
            dataGridProductos.CellContentClick += dataGridProductos_CellContentClick;
            // 
            // ABMProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1193, 552);
            Controls.Add(dataGridProductos);
            Controls.Add(lblProd);
            Controls.Add(comboAgregarProd);
            Controls.Add(btnActualizar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblCod);
            Name = "ABMProductos";
            Text = "ABMProductos";
            Load += ABMProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnActualizar;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label lblCod;
        private ComboBox comboAgregarProd;
        private Label lblProd;
        private DataGridView dataGridProductos;
    }
}