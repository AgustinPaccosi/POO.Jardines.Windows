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
    public partial class frmCategorias : Form
    {
        private readonly IServiciosCategoria _serviciosCategorias;
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
                RecargarGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void RecargarGrilla()
        {
            listaCategorias = _serviciosCategorias.GetCategorias();
            MostrarDatosEnGrilla();
            MostrarCantidad();
        }

        private void MostrarCantidad()
        {
            LblCantidad.Text = _serviciosCategorias.GetCantidad().ToString();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var categoria in listaCategorias)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, categoria);
                GridHelper.AgregarFila(dgvDatos, r);
            }
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
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCategoriasAE frm = new frmCategoriasAE(_serviciosCategorias) { Text = "Agregar Pais" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
            if (dr == DialogResult.Cancel) { return; }
            //try
            //{
            //    Categoria categoria = frm.GetCategoria();
            //    if (!_serviciosCategorias.Existe(categoria))
            //    {
            //        _serviciosCategorias.Guardar(categoria);
            //        DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
            //        GridHelper.SetearFila(r, categoria);
            //        GridHelper.AgregarFila(dgvDatos, r);

            //        MostrarCantidad();
            //        MessageBox.Show("Registro Agregado", "Mensaje",
            //            MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Registro Existente", "Mensaje",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message, "Mensaje",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
            Categoria categoriacopia = (Categoria)categoria.Clone();
            try
            {
                frmCategoriasAE frm = new frmCategoriasAE(_serviciosCategorias) { Text = "Editar Categoria" };
                frm.SetCategoria(categoria);

                DialogResult dr = frm.ShowDialog(this);
                RecargarGrilla();
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                
                //categoria = frm.GetCategoria();
                //if (!_serviciosCategorias.Existe(categoria))
                //{
                //    _serviciosCategorias.Guardar(categoria);
                //    GridHelper.SetearFila(r, categoria);
                //    MessageBox.Show("El registro se edito Correctamente",
                //        "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    GridHelper.SetearFila(r, categoriacopia);
                //    MessageBox.Show("Registro Duplicado", "Mensaje",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, categoriacopia);
                MessageBox.Show(ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
