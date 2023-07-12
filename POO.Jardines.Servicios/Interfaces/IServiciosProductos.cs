using POO.Jardines2023.Entidades.Entidades.Dtos.Cliente;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines.Servicios.Interfaces
{
    public interface IServiciosProductos
    {
        int GetCantidad();
        void Guardar(Producto producto);
        void Borrar(int productoId);
        bool Existe(Producto producto);
        Producto GetClientePorId(int productoId);
        List<Producto> GetProductos();
        //List<Producto> GetProductos(Categoria categoria);
        //List<ClienteListDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual);

    }
}
