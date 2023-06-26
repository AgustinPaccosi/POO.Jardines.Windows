namespace POO.Jardines.Windows
{
    partial class frmBuscaPaisCiudad
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboCiudades = new System.Windows.Forms.ComboBox();
            this.cboPaises = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ciudad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pais";
            // 
            // btnOk
            // 
            this.btnOk.Image = global::POO.Jardines.Windows.Properties.Resources.ok_24px;
            this.btnOk.Location = new System.Drawing.Point(108, 261);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(99, 74);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::POO.Jardines.Windows.Properties.Resources.cancel_24px;
            this.btnCancel.Location = new System.Drawing.Point(416, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 74);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboCiudades
            // 
            this.cboCiudades.FormattingEnabled = true;
            this.cboCiudades.Location = new System.Drawing.Point(161, 151);
            this.cboCiudades.Name = "cboCiudades";
            this.cboCiudades.Size = new System.Drawing.Size(354, 24);
            this.cboCiudades.TabIndex = 10;
            this.cboCiudades.SelectedIndexChanged += new System.EventHandler(this.cboCiudades_SelectedIndexChanged);
            // 
            // cboPaises
            // 
            this.cboPaises.FormattingEnabled = true;
            this.cboPaises.Location = new System.Drawing.Point(161, 104);
            this.cboPaises.Name = "cboPaises";
            this.cboPaises.Size = new System.Drawing.Size(354, 24);
            this.cboPaises.TabIndex = 11;
            this.cboPaises.SelectedIndexChanged += new System.EventHandler(this.cboPaises_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmBuscaPaisCiudad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 402);
            this.Controls.Add(this.cboCiudades);
            this.Controls.Add(this.cboPaises);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBuscaPaisCiudad";
            this.Text = "frmBuscaPaisCiudad";
            this.Load += new System.EventHandler(this.frmBuscaPaisCiudad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCiudades;
        private System.Windows.Forms.ComboBox cboPaises;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}