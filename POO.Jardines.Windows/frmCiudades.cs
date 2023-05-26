using POO.Jardines.Servicios.Interfaces;
using POO.Jardines.Servicios.Servicios;
using POO.Jardines.Windows.Helpers;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace POO.Jardines.Windows
{
    public partial class frmCiudades : Form
    {
        private readonly IServiciosCiudades _servicios;
        private List<Ciudad> listaCiudad;

        public frmCiudades()
        {
            InitializeComponent();
            _servicios= new ServiciosCiudades();
        }
        private void frmCiudades_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
            //try
            //{
            //    listaCiudad=_servicios.GetCiudades();
            //    MostrarDatosEnGrilla();
            //    MostrarCantidad();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        private void MostrarCantidad()
        {
            LblCantidad.Text = _servicios.GetCantidad().ToString();
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var ciudad in listaCiudad)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, ciudad);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCiudadesAE frm=new frmCiudadesAE() {Text= "Agregar Ciudad" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Ciudad ciudad = frm.GetCiudad();
                if (!_servicios.Existe(ciudad))
                {
                    _servicios.Guardar(ciudad);
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, ciudad);
                    GridHelper.AgregarFila(dgvDatos, r);

                    MessageBox.Show("Registro Agregardo", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro Duplicado", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Ciudad ciudad = (Ciudad)r.Tag;
            Ciudad ciudadcopia = (Ciudad)ciudad.Clone();
            try
            {
                frmCiudadesAE frm = new frmCiudadesAE() { Text = "Editar Ciudad" };
                frm.SetCiudad(ciudad);

                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                ciudad = frm.GetCiudad();
                if (!_servicios.Existe(ciudad))
                {
                    _servicios.Guardar(ciudad);
                    GridHelper.SetearFila(r, ciudad);
                    MessageBox.Show("El registro se edito Correctamente",
                        "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    GridHelper.SetearFila(r, ciudadcopia);
                    MessageBox.Show("Registro Duplicado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, ciudadcopia);
                MessageBox.Show(ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Ciudad ciudad = (Ciudad)r.Tag;
            try
            {
                DialogResult dr = MessageBox.Show("Desea borrar el registro Seleccionado?",
                "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
                _servicios.Borrar(ciudad.CiudadId);
                GridHelper.Quitarfila(dgvDatos, r);
                MessageBox.Show("Registro Borrado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmPaisesSeleccionar frm = new frmPaisesSeleccionar() { Text = "Seleccionar Pais" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                var pais = frm.GetPais();
                listaCiudad = _servicios.Filtrar(pais);
                LblCantidad.Text = _servicios.GetCantidadFiltrada(pais).ToString();
                btnBuscar.BackColor = Color.Orange;
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
            btnBuscar.BackColor = Color.White;

        }

        private void RecargarGrilla()
        {
            try
            {
                listaCiudad = _servicios.GetCiudades();
                MostrarDatosEnGrilla();
                MostrarCantidad();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
