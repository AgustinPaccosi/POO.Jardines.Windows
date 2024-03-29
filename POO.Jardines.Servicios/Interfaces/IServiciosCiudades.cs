﻿using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines.Servicios.Interfaces
{
    public interface IServiciosCiudades
    {
        void Guardar(Ciudad ciudad);
        void Borrar(int ciudadId);
        bool Existe(Ciudad ciudad);
        int GetCantidad(int? paisId);
        List<Ciudad> Filtrar(Pais pais);
        int GetCantidadFiltrada(Pais pais);
        //List<Ciudad> GetCiudades();
        List<Ciudad> GetCiudadesPorPagina(int registrosPorPagina, int paginaActual);
        List<Ciudad> GetCiudades(int? paisId);
    }
}
