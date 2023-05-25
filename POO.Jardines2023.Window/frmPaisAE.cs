using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.Jardines.Windows
{
    public partial class frmPaisAE : Form
    {
        public frmPaisAE()
        {
            InitializeComponent();
        }
        private Pais pais;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (pais != null)
            {
                txtPais.Text = pais.NombrePais;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (pais == null)
                {
                    pais=new Pais();
                }
                //pais=new Pais();
                pais.NombrePais=txtPais.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtPais.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPais, "Debe Ingreasar un pais!");

            }
            return valido;
        }

        public Pais GetPais()
        {
            return pais;
        }

        public void SetPais(Pais pais)
        {
            this.pais=pais;
        }
    }
}
