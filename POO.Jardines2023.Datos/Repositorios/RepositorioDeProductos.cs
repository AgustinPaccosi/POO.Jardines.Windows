using POO.Jardines2023.Datos.Interfaces;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines2023.Datos.Repositorios
{
    public class RepositorioDeProductos : IRepositorioDeProductos
    {
        private readonly string cadenaConexion;
        public RepositorioDeProductos()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public List<Producto> GetProductos()
        {
            try
            {
                List<Producto> listaprod = new List<Producto>();
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    var SelectQuery = @"SELECT p.ProductoId, p.NombreProducto, p.NombreLatin, p.CategoriaId, 
                                        p.UnidadesEnStock, p.NivelDeReposicion, c.NombreCategoria
                                        FROM dbo.Productos p
                                        inner join Categorias c on c.CategoriaId=p.CategoriaId";
                    using (var cmd = new SqlCommand(SelectQuery, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var producto = new Producto()
                                {
                                    ProductoId = reader.GetInt32(0),
                                    NombreProducto = reader.GetString(1),
                                    NombreLatin = reader.IsDBNull(2) ? "S/N" : reader.GetString(2),
                                    CategoriaId = reader.GetInt32(3),
                                    UnidadesEnStock = reader.GetInt32(4),
                                    NivelDeReposicion = reader.GetInt32(5),
                                    Categoria = reader.GetString(6)
                                };
                                listaprod.Add(producto);
                            }
                        }
                    }
                    return listaprod;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
