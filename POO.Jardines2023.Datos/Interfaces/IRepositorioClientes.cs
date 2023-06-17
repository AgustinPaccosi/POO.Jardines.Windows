using POO.Jardines2023.Entidades.Entidades.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines2023.Datos.Interfaces
{
    public interface IRepositorioClientes
    {
        int GetCantidad();
        List<ClienteListDto> GetClientes();
        List<ClienteListDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual);
    }
}
