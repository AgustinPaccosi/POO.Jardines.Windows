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
    public partial class frmPaises : Form
    {
        public frmPaises()
        {
            InitializeComponent();
            _servicios = new ServicioPaises();
        }
        private readonly ServicioPaises _servicios;
        private List<Pais> listapaises;

        //Para PAGINACION
        int paginaActual = 1;
        int registros = 0;
        int paginasTotales = 0;
        int registrosPorPagina = 5;

        bool filtroOn = false;
        string textoFiltro = null;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmPaises_Load(object sender, EventArgs e)
        {
            try
            {
                registros = _servicios.GetCantidad();
                paginasTotales = FormHelper.CalcularPaginas(registros, registrosPorPagina );
                RecargarGrilla();
                //listapaises = _servicios.GetPaisesPorPagina(registrosPorPagina, paginaActual);

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var pais in listapaises)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, pais);
                GridHelper.AgregarFila(dgvDatos,r);
            }
            LblCantidad.Text = _servicios.GetCantidad().ToString(); 
            lblPaginas1.Text=paginaActual.ToString();
            lblPaginas2.Text=paginasTotales.ToString();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmPaisAE frm=new frmPaisAE() {Text="Agregar Pais" };
            DialogResult dr=frm.ShowDialog(this);
            if (dr==DialogResult.Cancel) { return; }
            try
            {
                var pais = frm.GetPais();
                if (!_servicios.Existe(pais))
                {
                    _servicios.Guardar(pais);
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, pais);
                    GridHelper.AgregarFila(dgvDatos, r);
                    RecargarGrilla();
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
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Pais pais = (Pais)r.Tag;
            try
            {
                DialogResult dr = MessageBox.Show("Desea borrar el registro Seleccionado?",
                "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
                //Control de Relaciones;
                _servicios.Borrar(pais.PaisId);
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
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Pais pais = (Pais)r.Tag;
            Pais paiscopia = (Pais)pais.Clone();
            try
            {
                frmPaisAE frm = new frmPaisAE() { Text = "Editar Pais" };
                frm.SetPais(pais);

                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                pais = frm.GetPais();
                if (!_servicios.Existe(pais))
                {
                    _servicios.Guardar(pais);
                    GridHelper.SetearFila(r, pais);
                    MessageBox.Show("El registro se edito Correctamente",
                        "Editar", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    GridHelper.SetearFila(r, paiscopia);
                    MessageBox.Show("Registro Duplicado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, paiscopia);
                MessageBox.Show(ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!filtroOn)
            {
                frmBuscarPorNombre frm = new frmBuscarPorNombre();
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) return;
                try
                {
                    textoFiltro = frm.GetTexto();
                    btnBuscar.BackColor = Color.Orange;
                    filtroOn = true;
                    listapaises = _servicios.GetPaises(textoFiltro);
                    registros = _servicios.GetCantidad(textoFiltro);
                    paginasTotales = FormHelper.CalcularPaginas(registros, registrosPorPagina);
                    MostrarDatosEnGrilla();
                    LblCantidad.Text = _servicios.GetCantidad(textoFiltro).ToString();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                MessageBox.Show("Filtro ACTIVO", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //frmPaisesSeleccionar frm = new frmPaisesSeleccionar() { Text = "Seleccionar Pais" };
            //DialogResult dr = frm.ShowDialog(this);
            //if (dr == DialogResult.Cancel)
            //{
            //    return;
            //}
            //try
            //{
            //    var pais = frm.GetPais();
            //    listapaises = _servicios.Filtrar(pais);
            //    btnBuscar.BackColor = Color.Orange;
            //    MostrarDatosEnGrilla();

            //}
            //catch (Exception)
            //{
            //    throw;
            //}

        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            filtroOn = false;
            textoFiltro = null;
            btnBuscar.BackColor = Color.White;
            RecargarGrilla();
        }
        private void RecargarGrilla()
        {
            //listapaises = _servicios.GetPaises();
            listapaises = _servicios.GetPaisesPorPagina(registrosPorPagina, paginaActual);
            registros = _servicios.GetCantidad();
            paginasTotales = FormHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarDatosEnGrilla();
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual==paginasTotales)
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
            listapaises = _servicios.GetPaisesPorPagina(registrosPorPagina, paginaActual, textoFiltro);
            RecargarGrilla();
        }
    }
}
