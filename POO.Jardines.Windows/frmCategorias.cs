using POO.Jardines.Servicios.Interfaces;
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
    public partial class frmCategorias : Form
    {
        private readonly ServiciosCategoria _serviciosCategorias;
        private List<Categoria> listaCategorias;
        public frmCategorias()
        {
            InitializeComponent();
            _serviciosCategorias = new ServiciosCategorias();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                listaCategorias = _serviciosCategorias.GetCategorias();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void MostrarCantidad()
        {
            //LblCantidad.Text = _servicioCategorias.GetCantidad().ToString();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var categoria in listaCategorias)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, categoria);
                AgregarFila(r);
            }
        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
        private void SetearFila(DataGridViewRow r, Categoria categoria)
        {
            r.Cells[ColDescripcion.Index].Value = categoria.Descrpcion;
            r.Cells[ColCategoria.Index].Value = categoria.NombreCategoria;

            r.Tag = categoria;
        }
        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
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
                _serviciosCategorias.Borrar(categoria.CategoriaId);
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCategorias frm = new frmCategorias() { Text = "Agregar Pais" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                var categoria = frm.GetCategoria();
                if (!_serviciosCategorias.Existe(categoria))
                {
                    _serviciosCategorias.Guardar(categoria);
                    DataGridViewRow r = ConstruirFila();
                    SetearFila(r, categoria);
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

        private Categoria GetCategoria()
        {
            throw new NotImplementedException();
        }
    }
}
