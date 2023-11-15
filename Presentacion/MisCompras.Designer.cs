namespace Presentacion
{
    partial class MisCompras
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
            dataGridCompras = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridCompras).BeginInit();
            SuspendLayout();
            // 
            // dataGridCompras
            // 
            dataGridCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCompras.Location = new Point(12, 126);
            dataGridCompras.Name = "dataGridCompras";
            dataGridCompras.RowHeadersWidth = 51;
            dataGridCompras.RowTemplate.Height = 29;
            dataGridCompras.Size = new Size(764, 288);
            dataGridCompras.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 90);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 1;
            label1.Text = "Tus Compras:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(570, 93);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 7;
            label2.Text = "Orden";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "De mayor a menor venta", "De menor a mayor venta ", "Mas Reciente", "Mas Antiguo" });
            comboBox1.Location = new Point(625, 90);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // MisCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(dataGridCompras);
            Name = "MisCompras";
            Text = "MisCompras";
            Load += MisCompras_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridCompras).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridCompras;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
    }
}