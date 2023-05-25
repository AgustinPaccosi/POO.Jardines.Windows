using POO.Jardines.Servicios.Servicios;
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
            _servicio = new ServicioPaises();
        }
        private readonly ServicioPaises _servicio;
        private List<Pais> listapaises;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmPaises_Load(object sender, EventArgs e)
        {
            try
            {
                listapaises=_servicio.GetPaises();
                MostrarDatosEnGrilla();
                MostrarCantidad();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void MostrarCantidad()
        {
            LblCantidad.Text = _servicio.GetCantidad().ToString();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var pais in listapaises)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, pais);
                AgregarFila(r);
            }
        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
        private void SetearFila(DataGridViewRow r, Pais pais)
        {
            r.Cells[ColPais.Index].Value= pais.NombrePais;

            r.Tag = pais;
        }
        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmPaisAE frm=new frmPaisAE() {Text="Agregar Pais" };
            DialogResult dr=frm.ShowDialog(this);
            if (dr==DialogResult.Cancel) { return; }
            try
            {
                var pais = frm.GetPais();
                if (!_servicio.Existe(pais))
                {
                    _servicio.Guardar(pais);
                    DataGridViewRow r = ConstruirFila();
                    SetearFila(r, pais);
                    AgregarFila(r);
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
        private void toolStripButton3_Click(object sender, EventArgs e)
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
                _servicio.Borrar(pais.PaisId);
                Quitarfila(r);
                MessageBox.Show("Registro Borrado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Quitarfila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Pais pais = (Pais)r.Tag;
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
                if (!_servicio.Existe(pais))
                {
                    _servicio.Guardar(pais);
                    SetearFila(r, pais);
                    MessageBox.Show("El registro se edito Correctamente",
                        "Editar", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro Duplicado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
