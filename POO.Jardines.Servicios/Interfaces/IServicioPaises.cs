using POO.Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace POO.Jardines.Servicios.Interfaces
{
    public interface IServicioPaises
    {
        void Borrar(int paisId);
        bool Existe(Pais pais);
        int GetCantidad();
        List<Pais> GetPaises();
        void Guardar(Pais pais);
        Pais GetPaisPorId(int paisId);
    }
}