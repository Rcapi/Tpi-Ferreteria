namespace Presentacion
{
    partial class Carrito
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
            dataGridProdCarrito = new DataGridView();
            btnComprar = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            lblCod = new Label();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridProdCarrito).BeginInit();
            SuspendLayout();
            // 
            // dataGridProdCarrito
            // 
            dataGridProdCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProdCarrito.Location = new Point(12, 90);
            dataGridProdCarrito.Name = "dataGridProdCarrito";
            dataGridProdCarrito.RowHeadersWidth = 51;
            dataGridProdCarrito.RowTemplate.Height = 29;
            dataGridProdCarrito.Size = new Size(1067, 295);
            dataGridProdCarrito.TabIndex = 0;
            // 
            // btnComprar
            // 
            btnComprar.Location = new Point(972, 400);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(94, 29);
            btnComprar.TabIndex = 1;
            btnComprar.Text = "Comprar";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(564, 25);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(136, 45);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(402, 25);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(136, 45);
            btnBuscar.TabIndex = 15;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(109, 34);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(235, 27);
            txtBuscar.TabIndex = 14;
            // 
            // lblCod
            // 
            lblCod.AutoSize = true;
            lblCod.Location = new Point(33, 37);
            lblCod.Name = "lblCod";
            lblCod.Size = new Size(61, 20);
            lblCod.TabIndex = 13;
            lblCod.Text = "Codigo:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(795, 404);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(45, 20);
            lblTotal.TabIndex = 17;
            lblTotal.Text = "Total:";
           
            // 
            // Carrito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 450);
            Controls.Add(lblTotal);
            Controls.Add(btnEliminar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblCod);
            Controls.Add(btnComprar);
            Controls.Add(dataGridProdCarrito);
            Name = "Carrito";
            Text = "Carrito";
            Load += Carrito_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridProdCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridProdCarrito;
        private Button btnComprar;
        private Button btnEliminar;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label lblCod;
        private Label lblTotal;
    }
}