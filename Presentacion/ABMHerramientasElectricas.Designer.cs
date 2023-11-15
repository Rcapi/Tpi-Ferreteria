namespace Presentacion
{
    partial class ABMHerramientasElectricas
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
            txtCodigo = new TextBox();
            lblCodigo = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtDescripcion = new TextBox();
            lblDescipcion = new Label();
            txtPrecio = new TextBox();
            lblPrecio = new Label();
            btnGuardar = new Button();
            txtStock = new TextBox();
            lblStock = new Label();
            txtModelo = new TextBox();
            lblModelo = new Label();
            btnEliminar = new Button();
            txtPotencia = new TextBox();
            label1 = new Label();
            lblTipo = new Label();
            txtTipo = new TextBox();
            SuspendLayout();
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(97, 17);
            txtCodigo.Margin = new Padding(3, 4, 3, 4);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(171, 27);
            txtCodigo.TabIndex = 36;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(33, 24);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(58, 20);
            lblCodigo.TabIndex = 37;
            lblCodigo.Text = "Codigo";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(97, 71);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(171, 27);
            txtNombre.TabIndex = 38;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(27, 77);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 39;
            lblNombre.Text = "Nombre";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(97, 133);
            txtDescripcion.Margin = new Padding(3, 4, 3, 4);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(171, 27);
            txtDescripcion.TabIndex = 40;
            // 
            // lblDescipcion
            // 
            lblDescipcion.AutoSize = true;
            lblDescipcion.Location = new Point(4, 140);
            lblDescipcion.Name = "lblDescipcion";
            lblDescipcion.Size = new Size(87, 20);
            lblDescipcion.TabIndex = 41;
            lblDescipcion.Text = "Descripcion";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(97, 198);
            txtPrecio.Margin = new Padding(3, 4, 3, 4);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(171, 27);
            txtPrecio.TabIndex = 42;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(41, 205);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(50, 20);
            lblPrecio.TabIndex = 43;
            lblPrecio.Text = "Precio";
            lblPrecio.Click += lblPrecio_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(305, 254);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(96, 41);
            btnGuardar.TabIndex = 45;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(356, 14);
            txtStock.Margin = new Padding(3, 4, 3, 4);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(171, 27);
            txtStock.TabIndex = 47;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(305, 20);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(45, 20);
            lblStock.TabIndex = 48;
            lblStock.Text = "Stock";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(356, 74);
            txtModelo.Margin = new Padding(3, 4, 3, 4);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(171, 27);
            txtModelo.TabIndex = 49;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(289, 81);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(61, 20);
            lblModelo.TabIndex = 50;
            lblModelo.Text = "Modelo";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(176, 254);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(96, 41);
            btnEliminar.TabIndex = 72;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtPotencia
            // 
            txtPotencia.Location = new Point(356, 133);
            txtPotencia.Margin = new Padding(3, 4, 3, 4);
            txtPotencia.Name = "txtPotencia";
            txtPotencia.Size = new Size(171, 27);
            txtPotencia.TabIndex = 69;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(289, 140);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 70;
            label1.Text = "Potencia";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(311, 205);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(39, 20);
            lblTipo.TabIndex = 74;
            lblTipo.Text = "Tipo";
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(356, 198);
            txtTipo.Margin = new Padding(3, 4, 3, 4);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(171, 27);
            txtTipo.TabIndex = 73;
            // 
            // ABMHerramientasElectricas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 314);
            Controls.Add(lblTipo);
            Controls.Add(txtTipo);
            Controls.Add(btnEliminar);
            Controls.Add(label1);
            Controls.Add(txtPotencia);
            Controls.Add(lblModelo);
            Controls.Add(txtModelo);
            Controls.Add(lblStock);
            Controls.Add(txtStock);
            Controls.Add(btnGuardar);
            Controls.Add(lblPrecio);
            Controls.Add(txtPrecio);
            Controls.Add(lblDescipcion);
            Controls.Add(txtDescripcion);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblCodigo);
            Controls.Add(txtCodigo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ABMHerramientasElectricas";
            Text = "ABMHerramientasElectricas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCodigo;
        private Label lblCodigo;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtDescripcion;
        private Label lblDescipcion;
        private TextBox txtPrecio;
        private Label lblPrecio;
        private Button btnGuardar;
        private TextBox txtStock;
        private Label lblStock;
        private TextBox txtModelo;
        private Label lblModelo;
        private Button btnEliminar;
        private TextBox txtPotencia;
        private Label label1;
        private Label lblTipo;
        private TextBox txtTipo;
    }
}