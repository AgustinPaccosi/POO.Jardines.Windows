using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines2023.Datos.Interfaces
{
    public interface IRepositorioDeProductos
    {
        List<Producto> GetProductos();
    }
}
