using POO.Jardines.Servicios.Interfaces;
using POO.Jardines.Servicios.Servicios;
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
        private readonly IServiciosCiudades _serviciosCiudades;
        private bool esEdicion=false;
        public frmCiudadesAE(IServiciosCiudades _servicio)
        {
            InitializeComponent(); 
            _serviciosCiudades = _servicio;

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
                esEdicion=true;
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
                try
                {
                    if (!_serviciosCiudades.Existe(ciudad))
                    {
                        _serviciosCiudades.Guardar(ciudad);

                        if (esEdicion)
                        {
                            MessageBox.Show("Registro Editado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult dr = MessageBox.Show("Desea Agregar Otro Registro?", "Pregunta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.Cancel;
                            }
                            ciudad = null;
                            InicializarControles();

                        }
                        else
                        {

                            MessageBox.Show("Registro Agregado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //DialogResult = DialogResult.OK;
                            DialogResult dr = MessageBox.Show("Desea Agregar Otro Registro?", "Pregunta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.Cancel;
                            }
                            ciudad = null;
                            InicializarControles();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Registro Existente", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                //DialogResult = DialogResult.OK;

            }
        }

        private void InicializarControles()
        {
            cboPaises.SelectedIndex = 0;
            txtCiudades.Clear();
            cboPaises.Focus();
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

        private void btnAgregarPais_Click(object sender, EventArgs e)
        {
            var _serviciosPaises = new ServicioPaises();
            frmPaisAE frm = new frmPaisAE() { Text = "Agregar Pais" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                var pais = frm.GetPais();
                if (!_serviciosPaises.Existe(pais))
                {
                    _serviciosPaises.Guardar(pais);
                    MessageBox.Show("Registro Agregado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro Existente", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CombosHelper.CargarComboPaises(ref cboPaises);
        }
    }
}
