using POO.Jardines.Windows.Helpers;
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
    public partial class frmCiudadesAE : Form
    {
        public frmCiudadesAE()
        {
            InitializeComponent(); 
        }
        private Ciudad ciudad;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cboPaises);
            if (ciudad!=null)
            {
                txtCiudades.Text = ciudad.NombreCiudad;
                cboPaises.SelectedValue= ciudad.PaisId;
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
                if (ciudad==null)
                {
                    ciudad = new Ciudad();
                }
                ciudad.NombreCiudad=txtCiudades.Text;
                ciudad.Pais = (Pais)cboPaises.SelectedItem;
                ciudad.PaisId=(int)cboPaises.SelectedValue;//apunta al id del pais

                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboPaises.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un Pais");
            }
            if (string.IsNullOrEmpty(txtCiudades.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCiudades, "Ingrese una ciudad");
            }
            return valido;
        }

        public Ciudad GetCiudad()
        {
            return ciudad;
        }

        public void SetCiudad(Ciudad ciudad)
        {
            this.ciudad = ciudad;
        }
    }
}
