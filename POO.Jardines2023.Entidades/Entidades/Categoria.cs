﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines2023.Entidades.Entidades
{
    public class Categoria:ICloneable
    {
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
