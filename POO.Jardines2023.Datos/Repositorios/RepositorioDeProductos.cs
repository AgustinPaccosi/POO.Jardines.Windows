using POO.Jardines2023.Datos.Interfaces;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace POO.Jardines2023.Datos.Repositorios
{
    public class RepositorioDeProductos : IRepositorioDeProductos
    {
        private readonly string cadenaConexion;
        public RepositorioDeProductos()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Producto producto)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string InsertQuery = @"INSERT INTO[dbo].[Productos]
                            ([NombreProducto]
                           ,[NombreLatin]
                           ,[ProveedorId]
                           ,[CategoriaId]
                           ,[PrecioUnitario]
                           ,[UnidadesEnStock]
                           ,[UnidadesEnPedido]
                           ,[NivelDeReposicion]
                           ,[Suspendido]
                           ,[Imagen])
                     VALUES
                           (@NombreProducto, @NombreLatin, 1, @CategoriaId, 1, @UnidadesEnStock, 1, @NivelDeReposicion,
                           0,  NULL); SELECT SCOPE_IDENTITY()";

                using (var comando = new SqlCommand(InsertQuery, conn))
                {
                    comando.Parameters.Add("@NombreProducto", SqlDbType.NVarChar);
                    comando.Parameters["@NombreProducto"].Value = producto.NombreProducto;

                    comando.Parameters.Add("@NombreLatin", SqlDbType.NVarChar);
                    comando.Parameters["@NombreLatin"].Value = producto.NombreLatin;

                    comando.Parameters.Add("@CategoriaId", SqlDbType.Int);
                    comando.Parameters["@CategoriaId"].Value = producto.CategoriaId;

                    comando.Parameters.Add("@UnidadesEnStock", SqlDbType.Int);
                    comando.Parameters["@UnidadesEnStock"].Value = producto.UnidadesEnStock;

                    comando.Parameters.Add("@NivelDeReposicion", SqlDbType.Int);
                    comando.Parameters["@NivelDeReposicion"].Value = producto.NivelDeReposicion;

                    //ciudad.CiudadId = (int)comando.ExecuteScalar();
                    int Id = Convert.ToInt32(comando.ExecuteScalar());
                    producto.ProductoId = Id;
                }
            }

        }

        public bool Existe(Producto producto)
        {
            try
            {
                var cantidad = 0;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    String SelectQuery;
                    if (producto.ProductoId == 0)
                    {
                        SelectQuery = "SELECT COUNT(*) FROM dbo.Productos WHERE NombreProducto=@NombreProducto";
                    }
                    else
                    {
                        SelectQuery = "SELECT COUNT(*) FROM dbo.Productos WHERE NombreProducto=@NombreProducto AND ProductoId=@ProductoId";
                    }
                    using (var cmd = new SqlCommand(SelectQuery, conn))
                    {
                        cmd.Parameters.Add("@NombreProducto", SqlDbType.NVarChar);
                        cmd.Parameters["@NombreProducto"].Value = producto.NombreProducto;


                        if (producto.ProductoId != 0)
                        {
                            cmd.Parameters.Add("@ProductoId", SqlDbType.Int);
                            cmd.Parameters["@ProductoId"].Value = producto.ProductoId;
                        }
                        cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return cantidad > 0;

            }
            catch (Exception)
            {

                throw;
            }
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
                                    //Categoria = reader.GetString(6)
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
