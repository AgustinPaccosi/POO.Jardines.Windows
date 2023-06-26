using POO.Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace POO.Jardines.Servicios.Interfaces
{
    public interface IServicioPaises
    {
        void Borrar(int paisId);
        bool Existe(Pais pais);
        int GetCantidad(string textoFiltro);
        List<Pais> GetPaises();
        List<Pais> GetPaisesPorPagina(int cantidad, int paginaActual, string textoFiltro);
        //List<Pais> GetPaises(string textoFiltro);

        void Guardar(Pais pais);
        Pais GetPaisPorId(int paisId);
    }
}