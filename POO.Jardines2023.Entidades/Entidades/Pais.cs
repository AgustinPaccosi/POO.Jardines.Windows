using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines2023.Entidades.Entidades
{
    public class Pais:ICloneable
    {
        public int PaisId { get; set; } 
        public String NombrePais { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
