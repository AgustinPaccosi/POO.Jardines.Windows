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
    public partial class frmBuscaPaisCiudad : Form
    {
        public frmBuscaPaisCiudad()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmBuscaPaisCiudad_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboPaises(ref cboPaises);
        }
        private Pais paisSeleccionado;
        private Ciudad CiudadSeleccionada;
        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex > 0)
            {
                paisSeleccionado = (Pais)cboPaises.SelectedItem;
                CombosHelper.CargarCombooCiudades(ref cboCiudades, paisSeleccionado.PaisId);
            }
            else
            {
                paisSeleccionado = null;
                CiudadSeleccionada = null;
                cboCiudades.DataSource = null;
            }

        }

        private void cboCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCiudades.SelectedIndex>0)
            {
                CiudadSeleccionada = (Ciudad)cboCiudades.SelectedItem;
            }
            else
            {
                CiudadSeleccionada = null;
            }
        }
        public Pais GetPais()
        {
            return paisSeleccionado;
        }
        public Ciudad GetCiudad()
        {
            return CiudadSeleccionada;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Validardatos())
            {
                DialogResult= DialogResult.OK; 
            }
        }

        private bool Validardatos()
        {
            bool valido=true;
            errorProvider1.Clear();
            if (cboPaises.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Seleccione un Pais");
            }
            if (cboCiudades.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboCiudades, "Seleccione una Ciudad");
            }
            return valido;
        }
    }
}
