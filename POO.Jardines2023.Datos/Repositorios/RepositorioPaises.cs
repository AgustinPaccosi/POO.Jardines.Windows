using POO.Jardines2023.Datos.Interfaces;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines2023.Datos.Repositorios
{
    public class RepositorioPaises : IRepositorioPaises
    {
        //private SqlConnection _conn;
        private readonly string cadenaConexion;

        public RepositorioPaises()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Pais pais)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string InsertQuery = "INSERT INTO dbo.Paises (NombrePais) VALUES (@NombrePais); SELECT SCOPE_IDENTITY()";
                    using (var comando = new SqlCommand(InsertQuery, conn))
                    {
                        comando.Parameters.Add("@NombrePais", SqlDbType.NVarChar);
                        comando.Parameters["@NombrePais"].Value = pais.NombrePais;

                        //pais.PaisId = (int)comando.ExecuteScalar();
                        int Id = Convert.ToInt32(comando.ExecuteScalar());
                        pais.PaisId = Id;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Borrar(int PaisId)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM dbo.Paises where PaisId=@PaisId";
                    using (var comando = new SqlCommand(deleteQuery, conn))
                    {
                        comando.Parameters.Add("@PaisId", SqlDbType.Int);
                        comando.Parameters["@PaisId"].Value = PaisId;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Editar(Pais pais)
        {
            try
            {
                using (var conn= new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string UpdateQuery = "UPDATE dbo.Paises SET NombrePais=@NombrePais WHERE PaisId=@PaisId";
                    using (var cmd=new SqlCommand(UpdateQuery, conn))
                    {
                        cmd.Parameters.Add("@NombrePais", SqlDbType.NVarChar);
                        cmd.Parameters["@NombrePais"].Value = pais.NombrePais;

                        cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                        cmd.Parameters["@PaisId"].Value = pais.PaisId;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Pais> GetPaises()
        {
            try
            {
                List<Pais> listaPais = new List<Pais>();
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string SelectQuery = "SELECT PaisId, NombrePais FROM dbo.Paises ORDER BY NombrePais";
                    using (var comando = new SqlCommand(SelectQuery, conn))
                    {
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var paiss = ConstruirPais(reader);
                                listaPais.Add(paiss);
                            }
                        }
                    }
                }
                return listaPais;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public int GetCantidad()
        //{
        //    int cantidad = 0;
        //    try
        //    {
        //        using (var conn = new SqlConnection(cadenaConexion))
        //        {
        //            conn.Open();
        //            string CountQuery = "Select Count(*) FROM dbo.Paises";
        //            using (var comando = new SqlCommand(CountQuery, conn))
        //            {
        //                cantidad = (int)comando.ExecuteScalar();
        //            }

        //        }
        //        return cantidad;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public int GetCantidad(string textoFiltro=null)
        {
            int cantidad = 0;
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string SelectQuery;
                    if (textoFiltro == null)
                    {
                        SelectQuery = "Select Count(*) FROM dbo.Paises";
                    }
                    else
                    {
                        SelectQuery = "Select Count(*) FROM dbo.Paises WHERE NombrePais Like @textoFiltro"; 
                    }
                    using (var comando = new SqlCommand(SelectQuery, conn))
                    {
                        if(textoFiltro!=null)
                        {
                            comando.Parameters.Add("@textoFiltro", SqlDbType.NVarChar);
                            comando.Parameters["@textoFiltro"].Value = $"{textoFiltro}%";

                        }

                        cantidad = (int)comando.ExecuteScalar();
                    }

                }
                return cantidad;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool Existe(Pais pais)
        {
            try
            {
                var cantidad = 0;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string SelectQuery;
                    if (pais.PaisId == 0)
                    {
                        SelectQuery = "SELECT COUNT(*) FROM dbo.Paises WHERE NombrePais=@NombrePais";

                    }
                    else
                    {
                        SelectQuery = "SELECT COUNT(*) FROM dbo.Paises WHERE  NombrePais=@NombrePais AND PaisId!=@PaisId";

                    }
                    using (var comando = new SqlCommand(SelectQuery, conn))
                    {
                        comando.Parameters.Add("@NombrePais", SqlDbType.NVarChar);
                        comando.Parameters["@NombrePais"].Value = pais.NombrePais;
                        if (pais.PaisId!=0)
                        {
                            comando.Parameters.Add("@PaisId", SqlDbType.Int);
                            comando.Parameters["@PaisId"].Value = pais.PaisId;
                        }
                        cantidad = (int)comando.ExecuteScalar();
                    }
                }
                return cantidad > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Pais ConstruirPais(SqlDataReader reader)
        {
            return new Pais()
            {
                PaisId = reader.GetInt32(0),
                NombrePais = reader.GetString(1)
            };
        }
        public Pais GetPaisPorId(int paisId)
        {
            Pais pais = null;
            using (var conn=new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string SelectQuery = "SELECT PaisId, NombrePais FROM dbo.Paises WHERE PaisId=@PaisId";
                using (var cmd= new SqlCommand(SelectQuery, conn))
                {
                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value=paisId;
                    using (var reader=cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            pais = ConstruirPais(reader);

                        }
                    }
                }
            }
            return pais;
        }
        public List<Pais> GetPaisesPorPagina(int cantidad, int paginaActual, string textoFiltro=null)
        {
            try
            {
                List<Pais> listaPais = new List<Pais>();
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string SelectQuery;
                    if (textoFiltro==null)
                    {
                        SelectQuery = @"SELECT PaisId, NombrePais FROM dbo.Paises 
                                    ORDER BY NombrePais OFFSET @cantidadRegistros   
                                    ROWS FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    }
                    else
                    {
                        SelectQuery = @"SELECT PaisId, NombrePais FROM dbo.Paises 
                                    WHERE NombrePais LIKE @textoFiltro 
                                    ORDER BY NombrePais OFFSET @cantidadRegistros   
                                    ROWS FETCH NEXT @cantidadPorPagina ROWS ONLY";

                    }
                    using (var comando = new SqlCommand(SelectQuery, conn))
                    {
                        comando.Parameters.Add("@cantidadRegistros", SqlDbType.Int);
                        comando.Parameters["@cantidadRegistros"].Value = cantidad * (paginaActual - 1);

                        comando.Parameters.Add("@cantidadPorPagina", SqlDbType.Int);
                        comando.Parameters["@cantidadPorPagina"].Value = cantidad;
                        if (textoFiltro!=null)
                        {
                            comando.Parameters.Add("@textoFiltro", SqlDbType.NVarChar);
                            comando.Parameters["@textoFiltro"].Value = $"{textoFiltro}%";

                        }
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var paiss = ConstruirPais(reader);
                                listaPais.Add(paiss);
                            }
                        }
                    }
                }
                return listaPais;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //public List<Pais> FiltrarPais(Pais pais)
        //{
        //    List<Pais> listaPais = new List<Pais>();
        //    using (var conn = new SqlConnection(cadenaConexion))
        //    {
        //        conn.Open();
        //        string SelectQuery = "SELECT PaisId, NombrePais FROM dbo.Paises WHERE PaisId=@PaisId ";
        //        using (var comando = new SqlCommand(SelectQuery, conn))
        //        {
        //            comando.Parameters.Add("@PaisId", SqlDbType.Int);
        //            comando.Parameters["@PaisId"].Value = pais.PaisId;

        //            using (var reader = comando.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var paiss = ConstruirPais(reader);
        //                    listaPais.Add(paiss);
        //                }
        //            }
        //        }
        //    }
        //    return listaPais;
        //}


        public List<Pais> GetPaises(string textoFiltro)
        {
            try
            {
                List<Pais> listaPais = new List<Pais>();
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string SelectQuery = @"SELECT PaisId, NombrePais 
                            FROM dbo.Paises
                            WHERE NombrePais LIKE @textoFiltro
                            ORDER BY NombrePais";
                    using (var comando = new SqlCommand(SelectQuery, conn))
                    {
                        comando.Parameters.Add("@textoFiltro", SqlDbType.NVarChar);
                        comando.Parameters["@textoFiltro"].Value = $"{textoFiltro}%";

                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var paiss = ConstruirPais(reader);
                                listaPais.Add(paiss);
                            }
                        }
                    }
                }
                return listaPais;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
