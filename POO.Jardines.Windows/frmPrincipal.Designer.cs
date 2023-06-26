namespace POO.Jardines.Windows
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.btnPaises = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCiudades = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPaises
            // 
            this.btnPaises.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPaises.Image = ((System.Drawing.Image)(resources.GetObject("btnPaises.Image")));
            this.btnPaises.Location = new System.Drawing.Point(93, 75);
            this.btnPaises.Name = "btnPaises";
            this.btnPaises.Size = new System.Drawing.Size(152, 122);
            this.btnPaises.TabIndex = 0;
            this.btnPaises.Text = "Paises";
            this.btnPaises.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPaises.UseVisualStyleBackColor = false;
            this.btnPaises.Click += new System.EventHandler(this.btnPaises_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCerrar.Image = global::POO.Jardines.Windows.Properties.Resources.shutdown_48px;
            this.btnCerrar.Location = new System.Drawing.Point(612, 307);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(107, 91);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCiudades
            // 
            this.btnCiudades.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCiudades.Image = global::POO.Jardines.Windows.Properties.Resources.city_50px;
            this.btnCiudades.Location = new System.Drawing.Point(251, 75);
            this.btnCiudades.Name = "btnCiudades";
            this.btnCiudades.Size = new System.Drawing.Size(152, 122);
            this.btnCiudades.TabIndex = 1;
            this.btnCiudades.Text = "Ciudades";
            this.btnCiudades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCiudades.UseVisualStyleBackColor = false;
            this.btnCiudades.Click += new System.EventHandler(this.btnCiudades_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCategorias.Image = global::POO.Jardines.Windows.Properties.Resources.categorize_50px;
            this.btnCategorias.Location = new System.Drawing.Point(409, 75);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(152, 122);
            this.btnCategorias.TabIndex = 2;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnClientes.Image = global::POO.Jardines.Windows.Properties.Resources.client_management_50px;
            this.btnClientes.Location = new System.Drawing.Point(567, 75);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(152, 122);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.btnCiudades);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnPaises);
            this.MaximumSize = new System.Drawing.Size(900, 500);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPaises;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCiudades;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnClientes;
    }
}