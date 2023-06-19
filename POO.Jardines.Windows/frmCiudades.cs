using POO.Jardines.Servicios.Interfaces;
using POO.Jardines.Servicios.Servicios;
using POO.Jardines.Windows.Helpers;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace POO.Jardines.Windows
{
    public partial class frmCiudades : Form
    {
        private readonly IServiciosCiudades _serviciosCiudades;
        private List<Ciudad> listaCiudad;
        //Para PAGINACION
        int paginaActual = 1;
        int registros = 0;
        int paginasTotales = 0;
        int registrosPorPagina = 10;

        public frmCiudades()
        {
            InitializeComponent();
            _serviciosCiudades= new ServiciosCiudades();
        }
        private void frmCiudades_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
        private void RecargarGrilla()
        {
            try
            {
                registros = _serviciosCiudades.GetCantidad();
                paginasTotales = FormHelper.CalcularPaginas(registros, registrosPorPagina);
                listaCiudad = _serviciosCiudades.GetCiudadesPorPagina(registrosPorPagina, paginaActual);
                MostrarDatosEnGrilla();

                btnAnterior.Enabled = true;
                btnSiguiente.Enabled =  true;
                btnFin.Enabled = true;
                btnPrincipio.Enabled = true;
                btnBuscar.BackColor = Color.White;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            //List<Ciudad> ciudadesOrdenadas = listaCiudad.OrderBy(ciudad => ciudad.Pais.NombrePais).ToList();

            foreach (var ciudad in listaCiudad)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, ciudad);
                GridHelper.AgregarFila(dgvDatos, r);
            }
            LblCantidad.Text = _serviciosCiudades.GetCantidad().ToString();
            lblPaginas1.Text = paginaActual.ToString();
            lblPaginas2.Text = paginasTotales.ToString();

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCiudadesAE frm=new frmCiudadesAE(_serviciosCiudades) {Text= "Agregar Ciudad" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                RecargarGrilla();
                return;
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
                frmCiudadesAE frm = new frmCiudadesAE(_serviciosCiudades) { Text = "Editar Ciudad" };
                frm.SetCiudad(ciudad);

                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    RecargarGrilla();
                    return;
                }
                ciudad = frm.GetCiudad();
                GridHelper.SetearFila(r, ciudad);
                RecargarGrilla();
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
                _serviciosCiudades.Borrar(ciudad.CiudadId);
                GridHelper.Quitarfila(dgvDatos, r);
                RecargarGrilla();
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
                listaCiudad = _serviciosCiudades.Filtrar(pais);
                LblCantidad.Text = _serviciosCiudades.GetCantidadFiltrada(pais).ToString();
                btnBuscar.BackColor = Color.Orange;
                MostrarDatosEnGrilla();
                 
                btnAnterior.Enabled=false;
                btnSiguiente.Enabled=false;
                btnFin.Enabled=false;
                btnPrincipio.Enabled=false;
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

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual == paginasTotales)
            {
                return;
            }
            paginaActual++;
            MostrarPaginado();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual == 1)
            {
                return;
            }
            paginaActual--;
            MostrarPaginado();
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            paginaActual = paginasTotales;
            MostrarPaginado();
        }
        private void btnPrincipio_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();
        }

        private void MostrarPaginado()
        {
            listaCiudad = _serviciosCiudades.GetCiudadesPorPagina(registrosPorPagina, paginaActual);
            RecargarGrilla();
        }
    }
}
