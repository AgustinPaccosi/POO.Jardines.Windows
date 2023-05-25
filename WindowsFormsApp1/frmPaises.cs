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
                LblCantidad.Text = _servicio.GetCantidad().ToString();
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
    }
}
