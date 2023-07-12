using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines2023.Datos.Interfaces
{
    public interface IRepositorioCategorias
    {
        void Agregar(Categoria categoria);
        void Borrar(int CategoriaId);
        void Editar(Categoria categoria);
        bool Existe(Categoria categoria);
        int GetCantidad();
        Categoria GetCategoriaPorId(int categoriaId);
        List<Categoria> GetCategorias();
    }
}
