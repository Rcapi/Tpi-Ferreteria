namespace Presentacion
{
    partial class formMainCliente
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
            components = new System.ComponentModel.Container();
            lblBienvenido = new Label();
            menuProductos = new MenuStrip();
            cuentaToolStripMenuItem = new ToolStripMenuItem();
            datosToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            dataGridProductos = new DataGridView();
            productoBindingSource = new BindingSource(components);
            usuarioBindingSource = new BindingSource(components);
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            txtAgregar = new TextBox();
            label1 = new Label();
            btnAgregarAlCarrito = new Button();
            btnAbrirCarrito = new Button();
            btnCarrito = new Button();
            lblFiltro = new Label();
            comboBox2 = new ComboBox();
            misComprasToolStripMenuItem = new ToolStripMenuItem();
            verMisComprasToolStripMenuItem = new ToolStripMenuItem();
            menuProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblBienvenido.Location = new Point(447, 28);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(109, 25);
            lblBienvenido.TabIndex = 0;
            lblBienvenido.Text = "Bienvenido";
            lblBienvenido.Click += lblBienvenido_Click;
            // 
            // menuProductos
            // 
            menuProductos.ImageScalingSize = new Size(20, 20);
            menuProductos.Items.AddRange(new ToolStripItem[] { cuentaToolStripMenuItem, misComprasToolStripMenuItem });
            menuProductos.Location = new Point(0, 0);
            menuProductos.Name = "menuProductos";
            menuProductos.Size = new Size(1127, 28);
            menuProductos.TabIndex = 2;
            menuProductos.Text = "Productos";
            // 
            // cuentaToolStripMenuItem
            // 
            cuentaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { datosToolStripMenuItem, cerrarSesionToolStripMenuItem });
            cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            cuentaToolStripMenuItem.Size = new Size(69, 24);
            cuentaToolStripMenuItem.Text = "Cuenta";
            // 
            // datosToolStripMenuItem
            // 
            datosToolStripMenuItem.Name = "datosToolStripMenuItem";
            datosToolStripMenuItem.Size = new Size(224, 26);
            datosToolStripMenuItem.Text = "Datos";
            datosToolStripMenuItem.Click += datosToolStripMenuItem_Click;
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(224, 26);
            cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // dataGridProductos
            // 
            dataGridProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProductos.Location = new Point(12, 128);
            dataGridProductos.Name = "dataGridProductos";
            dataGridProductos.RowHeadersWidth = 51;
            dataGridProductos.Size = new Size(1081, 371);
            dataGridProductos.TabIndex = 3;
            dataGridProductos.CellContentClick += dataGridProductos_CellContentClick;
            // 
            // productoBindingSource
            // 
            productoBindingSource.DataSource = typeof(Entidades.Producto);
            // 
            // usuarioBindingSource
            // 
            usuarioBindingSource.DataSource = typeof(Entidades.Usuario);
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(174, 92);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(154, 27);
            txtBuscar.TabIndex = 4;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(356, 87);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 32);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += button1_Click;
            // 
            // txtAgregar
            // 
            txtAgregar.Location = new Point(12, 516);
            txtAgregar.Name = "txtAgregar";
            txtAgregar.Size = new Size(125, 27);
            txtAgregar.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 95);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 9;
            label1.Text = "Nombre del Producto:";
            // 
            // btnAgregarAlCarrito
            // 
            btnAgregarAlCarrito.Location = new Point(166, 516);
            btnAgregarAlCarrito.Name = "btnAgregarAlCarrito";
            btnAgregarAlCarrito.Size = new Size(162, 29);
            btnAgregarAlCarrito.TabIndex = 11;
            btnAgregarAlCarrito.Text = "Agregar al carrito";
            btnAgregarAlCarrito.UseVisualStyleBackColor = true;
            btnAgregarAlCarrito.Click += btnAgregarAlCarrito_Click_1;
            // 
            // btnAbrirCarrito
            // 
            btnAbrirCarrito.Location = new Point(787, 593);
            btnAbrirCarrito.Name = "btnAbrirCarrito";
            btnAbrirCarrito.Size = new Size(125, 29);
            btnAbrirCarrito.TabIndex = 12;
            btnAbrirCarrito.Text = "Ir a carrito";
            btnAbrirCarrito.UseVisualStyleBackColor = true;
            // 
            // btnCarrito
            // 
            btnCarrito.Location = new Point(917, 516);
            btnCarrito.Name = "btnCarrito";
            btnCarrito.Size = new Size(176, 29);
            btnCarrito.TabIndex = 13;
            btnCarrito.Text = "Ir al carrito";
            btnCarrito.UseVisualStyleBackColor = true;
            btnCarrito.Click += btnCarrito_Click_2;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new Point(943, 95);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(56, 20);
            lblFiltro.TabIndex = 15;
            lblFiltro.Text = "Filtros: ";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "+ Precio", "-  Precio", "A a Z", "Z a A " });
            comboBox2.Location = new Point(1005, 92);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(88, 28);
            comboBox2.TabIndex = 16;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // misComprasToolStripMenuItem
            // 
            misComprasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verMisComprasToolStripMenuItem });
            misComprasToolStripMenuItem.Name = "misComprasToolStripMenuItem";
            misComprasToolStripMenuItem.Size = new Size(109, 24);
            misComprasToolStripMenuItem.Text = "Mis Compras";
            // 
            // verMisComprasToolStripMenuItem
            // 
            verMisComprasToolStripMenuItem.Name = "verMisComprasToolStripMenuItem";
            verMisComprasToolStripMenuItem.Size = new Size(224, 26);
            verMisComprasToolStripMenuItem.Text = "Ver mis compras";
            verMisComprasToolStripMenuItem.Click += verMisComprasToolStripMenuItem_Click;
            // 
            // formMainCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1127, 584);
            Controls.Add(comboBox2);
            Controls.Add(lblFiltro);
            Controls.Add(btnCarrito);
            Controls.Add(btnAbrirCarrito);
            Controls.Add(btnAgregarAlCarrito);
            Controls.Add(label1);
            Controls.Add(txtAgregar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dataGridProductos);
            Controls.Add(lblBienvenido);
            Controls.Add(menuProductos);
            MainMenuStrip = menuProductos;
            Margin = new Padding(3, 4, 3, 4);
            Name = "formMainCliente";
            Text = "Cliente";
            Load += formMainCliente_Load;
            menuProductos.ResumeLayout(false);
            menuProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnCarrito_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label lblBienvenido;
        private MenuStrip menuProductos;
        private ToolStripMenuItem cuentaToolStripMenuItem;
        private ToolStripMenuItem datosToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private DataGridView dataGridProductos;
        private BindingSource productoBindingSource;
        private BindingSource usuarioBindingSource;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private TextBox txtAgregar;
        private Label label1;
        private Button btnAgregarAlCarrito;
        private Button btnAbrirCarrito;
        private Button btnCarrito;
        private Label lblFiltro;
        private ComboBox comboBox2;
        private ToolStripMenuItem misComprasToolStripMenuItem;
        private ToolStripMenuItem verMisComprasToolStripMenuItem;
    }
}