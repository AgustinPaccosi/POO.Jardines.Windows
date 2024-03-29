﻿using POO.Jardines.Servicios.Interfaces;
using POO.Jardines.Servicios.Servicios;
using POO.Jardines.Windows.Helpers;
using POO.Jardines2023.Datos.Repositorios;
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
    public partial class frmClientesAE : Form
    {
        private readonly IServiciosClientes _servicioClientes;
        private readonly IServiciosCiudades _servicioCiudades;

        public frmClientesAE(IServiciosClientes serviciosClientes)
        {
            InitializeComponent();
            _servicioClientes = serviciosClientes;
            _servicioCiudades = new ServiciosCiudades();
        }
        private Cliente cliente;
        private bool esEdicion = false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cboPaises);
            if (cliente != null)
            {
                txtNombres.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtDirec.Text = cliente.Direccion;
                txtEmail.Text = cliente.Email;
                txtCodPostal.Text = cliente.CodigoPostal;
                cboPaises.SelectedValue = cliente.PaisId;
                cboCiudades.SelectedValue = cliente.CiudadId;

                esEdicion = true;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cliente == null)
                {
                    cliente = new Cliente();
                }
                cliente.Nombre = txtNombres.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Direccion = txtDirec.Text;
                cliente.CodigoPostal=txtCodPostal.Text;
                cliente.Email = txtEmail.Text;
                cliente.TelefonoFijo=txtTelFijo.Text;
                cliente.TelefonoMovil = txtCel.Text;
                cliente.Pais = (Pais)cboPaises.SelectedItem;
                cliente.PaisId = (int)cboPaises.SelectedValue;
                cliente.Ciudad = (Ciudad)cboCiudades.SelectedItem;
                cliente.CiudadId = (int)cboCiudades.SelectedValue;
                try
                {
                    if (!_servicioClientes.Existe(cliente))
                    {
                        _servicioClientes.Guardar(cliente);

                        if (!esEdicion)
                        {
                            MessageBox.Show("Registro Agregado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult dr = MessageBox.Show("Desea Agregar Otro Registro?", "Pregunta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.Cancel; ;
                            }
                            cliente = null;
                            InicializarControles();
                        }
                        else
                        {
                            MessageBox.Show("Registro Editado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
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
            }
        }


        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombres, "Ingrese Un Nombre");
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "Ingrese Un Apellido");
            }
            if (string.IsNullOrEmpty(txtDirec.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDirec, "Ingrese la Direccion");
            }
            if (string.IsNullOrEmpty(txtCodPostal.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCodPostal, "Ingrese El CodigoPostal");
            }
            if (cboPaises.SelectedIndex == 0) 
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Seleccionar Un Pais");
            }
            if (cboCiudades.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCiudades, "Seleccionar Una Ciudad");
            }
            return valido;

        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex > 0)
            {
                var pais =(Pais)cboPaises.SelectedItem;
                CombosHelper.CargarCombooCiudades(ref cboCiudades, pais.PaisId);
            }
            else
            {
                cboCiudades.DataSource = null;
            }
        }

        public void SetCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public Cliente GetCliente()
        {
            return cliente;
        }
        private void InicializarControles()
        {
            txtNombres.Clear();
            txtApellido.Clear();
            txtDirec.Clear();
            txtCodPostal.Clear();
            txtEmail.Clear();
            txtTelFijo.Clear();
            txtCel.Clear();
            cboPaises.SelectedIndex = 0;
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

        private void btnAgregarCiudad_Click(object sender, EventArgs e)
        {
            frmCiudadesAE frm = new frmCiudadesAE(_servicioCiudades) { Text = "Agregar Ciudad" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

        }
    }
}
