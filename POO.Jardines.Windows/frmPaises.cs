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
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmPaises_Load(object sender, EventArgs e)
        {
            try
            {
                RecargarGrilla();
                MostrarCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void MostrarCantidad()
        {
            LblCantidad.Text = _servicios.GetCantidad().ToString();
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
        }
        //private void AgregarFila(DataGridViewRow r)
        //{
        //    dgvDatos.Rows.Add(r);
        //}
        //private void SetearFila(DataGridViewRow r, Pais pais)
        //{
        //    r.Cells[ColPais.Index].Value= pais.NombrePais;

        //    r.Tag = pais;
        //}
        //private DataGridViewRow ConstruirFila()
        //{
        //    DataGridViewRow r = new DataGridViewRow();
        //    r.CreateCells(dgvDatos);
        //    return r;
        //}
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
                    MostrarCantidad();
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
                MostrarCantidad();
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
            frmPaisesSeleccionar frm = new frmPaisesSeleccionar() { Text = "Seleccionar Pais" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                var pais = frm.GetPais();
                listapaises = _servicios.Filtrar(pais);
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
            listapaises = _servicios.GetPaises();
            MostrarDatosEnGrilla();
        }

    }
}
