namespace Presentacion
{
    partial class Compra
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
            lblDni = new Label();
            txtDni = new TextBox();
            txtCiudad = new TextBox();
            lblCiudad = new Label();
            txtDireccion = new TextBox();
            lblDireccion = new Label();
            txtTelefono = new TextBox();
            txtMail = new TextBox();
            txtApellido = new TextBox();
            lblTelefono = new Label();
            lblMail = new Label();
            lblApellido = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            lblTotal = new Label();
            dataGridView = new DataGridView();
            btnComprar = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            txtMetodo = new TextBox();
            lblMetodo = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblDni.Location = new Point(17, 37);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(42, 22);
            lblDni.TabIndex = 111;
            lblDni.Text = "Dni:";
            // 
            // txtDni
            // 
            txtDni.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtDni.Location = new Point(101, 29);
            txtDni.Margin = new Padding(3, 4, 3, 4);
            txtDni.Name = "txtDni";
            txtDni.ReadOnly = true;
            txtDni.Size = new Size(251, 28);
            txtDni.TabIndex = 110;
            // 
            // txtCiudad
            // 
            txtCiudad.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtCiudad.Location = new Point(522, 82);
            txtCiudad.Margin = new Padding(3, 4, 3, 4);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.ReadOnly = true;
            txtCiudad.Size = new Size(255, 28);
            txtCiudad.TabIndex = 108;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblCiudad.Location = new Point(444, 85);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(72, 22);
            lblCiudad.TabIndex = 106;
            lblCiudad.Text = "Ciudad:";
            // 
            // txtDireccion
            // 
            txtDireccion.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtDireccion.Location = new Point(522, 28);
            txtDireccion.Margin = new Padding(3, 4, 3, 4);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.ReadOnly = true;
            txtDireccion.Size = new Size(255, 28);
            txtDireccion.TabIndex = 105;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblDireccion.Location = new Point(426, 32);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(90, 22);
            lblDireccion.TabIndex = 104;
            lblDireccion.Text = "Direccion:";
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefono.Location = new Point(101, 224);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.ReadOnly = true;
            txtTelefono.Size = new Size(251, 28);
            txtTelefono.TabIndex = 103;
            // 
            // txtMail
            // 
            txtMail.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtMail.Location = new Point(101, 177);
            txtMail.Margin = new Padding(3, 4, 3, 4);
            txtMail.Name = "txtMail";
            txtMail.ReadOnly = true;
            txtMail.Size = new Size(251, 28);
            txtMail.TabIndex = 102;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtApellido.Location = new Point(101, 128);
            txtApellido.Margin = new Padding(3, 4, 3, 4);
            txtApellido.Name = "txtApellido";
            txtApellido.ReadOnly = true;
            txtApellido.Size = new Size(251, 28);
            txtApellido.TabIndex = 101;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblTelefono.Location = new Point(18, 229);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(86, 22);
            lblTelefono.TabIndex = 100;
            lblTelefono.Text = "Telefono:";
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblMail.Location = new Point(18, 183);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(59, 22);
            lblMail.TabIndex = 99;
            lblMail.Text = "Email:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblApellido.Location = new Point(18, 133);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(79, 22);
            lblApellido.TabIndex = 98;
            lblApellido.Text = "Apellido:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(101, 79);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(251, 28);
            txtNombre.TabIndex = 97;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(17, 82);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(78, 22);
            lblNombre.TabIndex = 96;
            lblNombre.Text = "Nombre:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotal.Location = new Point(522, 180);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(80, 22);
            lblTotal.TabIndex = 112;
            lblTotal.Text = "TOTAL :";
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(18, 271);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(885, 204);
            dataGridView.TabIndex = 113;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // btnComprar
            // 
            btnComprar.Location = new Point(522, 210);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(219, 55);
            btnComprar.TabIndex = 114;
            btnComprar.Text = "Realizar compra";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // txtMetodo
            // 
            txtMetodo.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtMetodo.Location = new Point(522, 131);
            txtMetodo.Margin = new Padding(3, 4, 3, 4);
            txtMetodo.Name = "txtMetodo";
            txtMetodo.Size = new Size(255, 28);
            txtMetodo.TabIndex = 116;
            txtMetodo.Text = "\r\n";
            // 
            // lblMetodo
            // 
            lblMetodo.AutoSize = true;
            lblMetodo.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblMetodo.Location = new Point(374, 134);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(139, 22);
            lblMetodo.TabIndex = 115;
            lblMetodo.Text = "Metodo de pago";
            // 
            // Compra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 487);
            Controls.Add(txtMetodo);
            Controls.Add(lblMetodo);
            Controls.Add(btnComprar);
            Controls.Add(dataGridView);
            Controls.Add(lblTotal);
            Controls.Add(lblDni);
            Controls.Add(txtDni);
            Controls.Add(txtCiudad);
            Controls.Add(lblCiudad);
            Controls.Add(txtDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(txtMail);
            Controls.Add(txtApellido);
            Controls.Add(lblTelefono);
            Controls.Add(lblMail);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Name = "Compra";
            Text = "Compra";
            Load += Compra_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDni;
        private TextBox txtDni;
        private TextBox txtCiudad;
        private Label lblCiudad;
        private TextBox txtDireccion;
        private Label lblDireccion;
        private TextBox txtTelefono;
        private TextBox txtMail;
        private TextBox txtApellido;
        private Label lblTelefono;
        private Label lblMail;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblTotal;
        private DataGridView dataGridView;
        private Button btnComprar;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private TextBox txtMetodo;
        private Label lblMetodo;
    }
}