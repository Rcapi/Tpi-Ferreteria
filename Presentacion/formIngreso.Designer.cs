namespace Presentacion
{
    partial class formIngreso
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
            btnCancelar = new Button();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            lblClave = new Label();
            lblTitulo = new Label();
            btnIngresar = new Button();
            linkLblRegistro = new LinkLabel();
            lblLinkRegistro = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.Location = new Point(454, 386);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(117, 51);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.Location = new Point(92, 169);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(86, 25);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsuario.Location = new Point(255, 169);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(360, 30);
            txtUsuario.TabIndex = 4;
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.Location = new Point(255, 261);
            txtClave.Margin = new Padding(3, 4, 3, 4);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(360, 30);
            txtClave.TabIndex = 5;
            txtClave.UseSystemPasswordChar = true;
            txtClave.TextChanged += txtClave_TextChanged;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblClave.Location = new Point(92, 261);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(68, 25);
            lblClave.TabIndex = 6;
            lblClave.Text = "Clave";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 19.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(90, 32);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(553, 38);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "Bienvenido al sistema de ferreteria";
            // 
            // btnIngresar
            // 
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnIngresar.Location = new Point(597, 386);
            btnIngresar.Margin = new Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(116, 51);
            btnIngresar.TabIndex = 8;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // linkLblRegistro
            // 
            linkLblRegistro.AutoSize = true;
            linkLblRegistro.Cursor = Cursors.Hand;
            linkLblRegistro.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            linkLblRegistro.Location = new Point(32, 418);
            linkLblRegistro.Name = "linkLblRegistro";
            linkLblRegistro.Size = new Size(96, 20);
            linkLblRegistro.TabIndex = 9;
            linkLblRegistro.TabStop = true;
            linkLblRegistro.Text = "Ingresa aca";
            linkLblRegistro.LinkClicked += linkLblRegistro_LinkClicked;
            // 
            // lblLinkRegistro
            // 
            lblLinkRegistro.AutoSize = true;
            lblLinkRegistro.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblLinkRegistro.Location = new Point(25, 386);
            lblLinkRegistro.Name = "lblLinkRegistro";
            lblLinkRegistro.Size = new Size(135, 25);
            lblLinkRegistro.TabIndex = 10;
            lblLinkRegistro.Text = "Para registro";
            // 
            // formIngreso
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 452);
            Controls.Add(lblLinkRegistro);
            Controls.Add(linkLblRegistro);
            Controls.Add(btnIngresar);
            Controls.Add(lblTitulo);
            Controls.Add(lblClave);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(btnCancelar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "formIngreso";
            Text = "Menu Ingreso";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancelar;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Label lblClave;
        private Label lblTitulo;
        private Button btnIngresar;
        private LinkLabel linkLblRegistro;
        private Label lblLinkRegistro;
    }
}

