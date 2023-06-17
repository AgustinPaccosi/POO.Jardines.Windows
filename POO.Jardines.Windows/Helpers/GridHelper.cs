using POO.Jardines2023.Entidades.Entidades;
using POO.Jardines2023.Entidades.Entidades.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.Jardines.Windows.Helpers
{
    public static class GridHelper
    {
        public static void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }
        public static DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;
        }
        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case Pais pais:
                    r.Cells[0].Value = pais.NombrePais;
                    break;
                case Ciudad ciudad:
                    r.Cells[0].Value = ciudad.Pais.NombrePais;
                    r.Cells[1].Value = ciudad.NombreCiudad;
                    break;
                case Categoria categoria:
                    r.Cells[0].Value = categoria.NombreCategoria;
                    r.Cells[1].Value = categoria.Descripcion;
                    break;
                case ClienteListDto cliente:
                    r.Cells[0].Value = cliente.NombrePais;
                    r.Cells[1].Value = cliente.NombreCiudad;
                    r.Cells[2].Value = cliente.Apellido + ", "+ cliente.Nombre;
                    break;

            }
            r.Tag = obj;
        }
        public static void AgregarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Add(r);
        }

        public static void Quitarfila(DataGridView dgv,DataGridViewRow r)
        {
            dgv.Rows.Remove(r);
        }
    }
}
