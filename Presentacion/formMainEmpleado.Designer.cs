namespace Presentacion
{
    partial class formMainEmpleado
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
            lblBienvenido = new Label();
            menuStripEmpleado = new MenuStrip();
            cuentaToolStripMenuItem = new ToolStripMenuItem();
            modificarDatosToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            agregarEliminarModificarToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            agregarEliminarModificarToolStripMenuItem1 = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            graficosToolStripMenuItem = new ToolStripMenuItem();
            verVentasToolStripMenuItem = new ToolStripMenuItem();
            menuStripEmpleado.SuspendLayout();
            SuspendLayout();
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblBienvenido.Location = new Point(382, 102);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(109, 25);
            lblBienvenido.TabIndex = 0;
            lblBienvenido.Text = "Bienvenido";
            lblBienvenido.Click += label1_Click;
            // 
            // menuStripEmpleado
            // 
            menuStripEmpleado.ImageScalingSize = new Size(20, 20);
            menuStripEmpleado.Items.AddRange(new ToolStripItem[] { cuentaToolStripMenuItem, productosToolStripMenuItem, clientesToolStripMenuItem, ventasToolStripMenuItem });
            menuStripEmpleado.Location = new Point(0, 0);
            menuStripEmpleado.Name = "menuStripEmpleado";
            menuStripEmpleado.Size = new Size(948, 28);
            menuStripEmpleado.TabIndex = 1;
            menuStripEmpleado.Text = "menuEmpleado";
            // 
            // cuentaToolStripMenuItem
            // 
            cuentaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { modificarDatosToolStripMenuItem, cerrarSesionToolStripMenuItem });
            cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            cuentaToolStripMenuItem.Size = new Size(69, 24);
            cuentaToolStripMenuItem.Text = "Cuenta";
            // 
            // modificarDatosToolStripMenuItem
            // 
            modificarDatosToolStripMenuItem.Name = "modificarDatosToolStripMenuItem";
            modificarDatosToolStripMenuItem.Size = new Size(177, 26);
            modificarDatosToolStripMenuItem.Text = "Datos";
            modificarDatosToolStripMenuItem.Click += modificarDatosToolStripMenuItem_Click;
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(177, 26);
            cerrarSesionToolStripMenuItem.Text = "Cerrar sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarEliminarModificarToolStripMenuItem });
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(89, 24);
            productosToolStripMenuItem.Text = "Productos";
            // 
            // agregarEliminarModificarToolStripMenuItem
            // 
            agregarEliminarModificarToolStripMenuItem.Name = "agregarEliminarModificarToolStripMenuItem";
            agregarEliminarModificarToolStripMenuItem.Size = new Size(284, 26);
            agregarEliminarModificarToolStripMenuItem.Text = "Agregar/ Eliminar/ Modificar";
            agregarEliminarModificarToolStripMenuItem.Click += agregarEliminarModificarToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarEliminarModificarToolStripMenuItem1 });
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(75, 24);
            clientesToolStripMenuItem.Text = "Clientes";
            // 
            // agregarEliminarModificarToolStripMenuItem1
            // 
            agregarEliminarModificarToolStripMenuItem1.Name = "agregarEliminarModificarToolStripMenuItem1";
            agregarEliminarModificarToolStripMenuItem1.Size = new Size(288, 26);
            agregarEliminarModificarToolStripMenuItem1.Text = "Agregar/ Eliminar / Modificar";
            agregarEliminarModificarToolStripMenuItem1.Click += agregarEliminarModificarToolStripMenuItem1_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { graficosToolStripMenuItem, verVentasToolStripMenuItem });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(66, 24);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // graficosToolStripMenuItem
            // 
            graficosToolStripMenuItem.Name = "graficosToolStripMenuItem";
            graficosToolStripMenuItem.Size = new Size(160, 26);
            graficosToolStripMenuItem.Text = "Graficos";
            graficosToolStripMenuItem.Click += graficosToolStripMenuItem_Click;
            // 
            // verVentasToolStripMenuItem
            // 
            verVentasToolStripMenuItem.Name = "verVentasToolStripMenuItem";
            verVentasToolStripMenuItem.Size = new Size(160, 26);
            verVentasToolStripMenuItem.Text = "Ver Ventas";
            verVentasToolStripMenuItem.Click += verVentasToolStripMenuItem_Click;
            // 
            // formMainEmpleado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 624);
            Controls.Add(lblBienvenido);
            Controls.Add(menuStripEmpleado);
            MainMenuStrip = menuStripEmpleado;
            Margin = new Padding(3, 4, 3, 4);
            Name = "formMainEmpleado";
            Text = "formMainEmpleado";
            Load += formMainEmpleado_Load;
            menuStripEmpleado.ResumeLayout(false);
            menuStripEmpleado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenido;
        private MenuStrip menuStripEmpleado;
        private ToolStripMenuItem cuentaToolStripMenuItem;
        private ToolStripMenuItem modificarDatosToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem agregarEliminarModificarToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem agregarEliminarModificarToolStripMenuItem1;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem graficosToolStripMenuItem;
        private ToolStripMenuItem verVentasToolStripMenuItem;
    }
}