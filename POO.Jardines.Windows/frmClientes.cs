using POO.Jardines.Servicios.Interfaces;
using POO.Jardines.Servicios.Servicios;
using POO.Jardines.Windows.Helpers;
using POO.Jardines2023.Entidades.Entidades.Dtos.Cliente;
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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            _serviciosClientes = new ServiciosClientes();
        }

        int paginaActual = 1;
        int registros = 0;
        int paginasTotales = 0;
        int registrosPorPagina = 10;


        List<ClienteListDto> listaClienteDto=new List<ClienteListDto>();
        private readonly IServiciosClientes _serviciosClientes;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                //listaClienteDto = _serviciosClientes.GetClientes();
                RecargarGrilla();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void RecargarGrilla()
        {
            try
            {
                registros = _serviciosClientes.GetCantidad();
                paginasTotales = FormHelper.CalcularPaginas(registros, registrosPorPagina);
                listaClienteDto = _serviciosClientes.GetClientesPorPagina(registrosPorPagina, paginaActual);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var cliente in listaClienteDto)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, cliente);
                GridHelper.AgregarFila(dgvDatos, r);
            }
            LblCantidad.Text = _serviciosClientes.GetCantidad().ToString();
            lblPaginas1.Text = paginaActual.ToString();
            lblPaginas2.Text = paginasTotales.ToString();

        }

        private void btnPrincipio_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
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

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual == paginasTotales)
            {
                return;
            }
            paginaActual++;
            MostrarPaginado();

        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            paginaActual = paginasTotales;
            MostrarPaginado();

        }
        private void MostrarPaginado()
        {
            listaClienteDto = _serviciosClientes.GetClientesPorPagina(registrosPorPagina, paginaActual);
            RecargarGrilla();
        }

    }
}
