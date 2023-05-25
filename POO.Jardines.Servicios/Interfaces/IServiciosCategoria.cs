using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines.Servicios.Interfaces
{
    public interface ServiciosCategoria
    {
        void Guardar(Categoria categoria);
        void Borrar(int categoriaId);
        bool Existe(Categoria categoria);
        int GetCantidad();
        List<Categoria> GetCategorias();
    }
}
