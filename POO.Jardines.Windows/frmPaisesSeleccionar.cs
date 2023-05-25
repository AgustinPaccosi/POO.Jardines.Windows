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
    public partial class frmPaisesSeleccionar : Form
    {
        public frmPaisesSeleccionar()
        {
            InitializeComponent();
        }
        private Pais paisSeleccionado;

        private void frmPaisesSeleccionar_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboPaises(ref cboPaises);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                paisSeleccionado=(Pais)cboPaises.SelectedItem;
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
                errorProvider1.SetError(cboPaises, "Debe seleccionar un pais");
            }
            return valido;
        }

        public Pais GetPais()
        {
            return paisSeleccionado;
        }
    }
}
