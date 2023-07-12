using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines2023.Entidades.Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set;}
        public string NombreLatin {get; set;}
        public int CategoriaId { get; set;}
        public string Categoria { get; set;}
        public int UnidadesEnStock { get; set;}
        public int NivelDeReposicion { get; set;}
    }
}
