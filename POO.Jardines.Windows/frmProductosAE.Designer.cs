namespace POO.Jardines.Windows
{
    partial class frmProductosAE
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
            this.components = new System.ComponentModel.Container();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.cboCategorias = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLatin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReposicion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(130, 48);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(369, 22);
            this.txtProducto.TabIndex = 9;
            // 
            // cboCategorias
            // 
            this.cboCategorias.FormattingEnabled = true;
            this.cboCategorias.Location = new System.Drawing.Point(130, 93);
            this.cboCategorias.Name = "cboCategorias";
            this.cboCategorias.Size = new System.Drawing.Size(369, 24);
            this.cboCategorias.TabIndex = 8;
            // 
            // btnOk
            // 
            this.btnOk.Image = global::POO.Jardines.Windows.Properties.Resources.ok_24px;
            this.btnOk.Location = new System.Drawing.Point(130, 296);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(99, 74);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::POO.Jardines.Windows.Properties.Resources.cancel_24px;
            this.btnCancel.Location = new System.Drawing.Point(400, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 74);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Categoria";
            // 
            // txtLatin
            // 
            this.txtLatin.Location = new System.Drawing.Point(160, 160);
            this.txtLatin.Name = "txtLatin";
            this.txtLatin.Size = new System.Drawing.Size(339, 22);
            this.txtLatin.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nombre en Latin";
            // 
            // txtReposicion
            // 
            this.txtReposicion.Location = new System.Drawing.Point(160, 221);
            this.txtReposicion.Name = "txtReposicion";
            this.txtReposicion.Size = new System.Drawing.Size(232, 22);
            this.txtReposicion.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Nivel De Reposicion";
            // 
            // textStock
            // 
            this.textStock.Location = new System.Drawing.Point(491, 221);
            this.textStock.Name = "textStock";
            this.textStock.Size = new System.Drawing.Size(144, 22);
            this.textStock.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Stock";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmProductosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 450);
            this.Controls.Add(this.txtReposicion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textStock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLatin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.cboCategorias);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmProductosAE";
            this.Text = "frmProductosAE";
            this.Load += new System.EventHandler(this.frmProductosAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.ComboBox cboCategorias;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLatin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReposicion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}