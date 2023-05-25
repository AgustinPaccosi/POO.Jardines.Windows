using POO.Jardines.Servicios.Interfaces;
using POO.Jardines.Servicios.Servicios;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.Jardines.Windows.Helpers
{
    public static class CombosHelper
    {
        public static void CargarComboPaises(ref ComboBox combo)
        {
            IServicioPaises servicioPaises= new ServicioPaises();
            var listapaises=servicioPaises.GetPaises();
            var defaultPais = new Pais()
            {
                PaisId = 0,
                NombrePais = "Seleccionar Pais"
            };
            listapaises.Insert(0, defaultPais);
            combo.DataSource=listapaises;
            combo.DisplayMember = "NombrePais";
            combo.ValueMember = "PaisId";
            combo.SelectedIndex = 0;
        }
    }
}
