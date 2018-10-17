using Chinook.Etities.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.DataAccess
{
    public class ArtistRepositor
    {
        public void DeleteArtist(int iArtist)
        {
            string CadenaConexion = "server=(local); database=Chinook; User Id=sa; Pwd=sql";
            using (var connection = new SqlConnection(CadenaConexion))
            {
                connection.Open();
                SqlCommand Command =new SqlCommand("usp_DeleteArtist", connection);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@ArtistId", iArtist);
                Command.ExecuteNonQuery();
            }

        }
        //Insertar Artista dentro de un bloque de transaccion 
        public int InsertArtistTX(Artist artist)
        {
            int result = 0;
            string CadenaConexion = "server=(local); database=Chinook; User Id=sa; Pwd=sql";
            using (var connection = new SqlConnection(CadenaConexion))
            {
                //Abriendo la conexion en la Base de Datos 
                connection.Open();

                var Transaction = connection.BeginTransaction();

                var Command = new SqlCommand("usp_InsertArtist", connection);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                //Asociando al objeto command la transaccion inicializada lineas antes.
                Command.Transaction = Transaction;
                Command.Parameters.AddWithValue("@Name", artist.Name);
                try
                {
                    result = Convert.ToInt32(Command.ExecuteScalar());
                    //throw new Exception("se cayo la base de datos");
                    //Confirmando la Transaccion
                    Transaction.Commit();
                }
                catch (Exception)
                {
                    result = -1;
                    //Se realiza el RollBack de los cambios realizados 
                    Transaction.Rollback();
                }
            }
            return result;
        }
        public int InsertArtist(Artist artist)
        {
            int result = 0;
            string CadenaConexion = "server=(local); database=Chinook; User Id=sa; Pwd=sql";
            using (var connection = new SqlConnection(CadenaConexion))
            {
                //Abriendo la conexion en la Base de Datos 
                connection.Open();
                var Command = new SqlCommand("usp_InsertArtist",connection);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@Name", artist.Name);

                result =Convert.ToInt32(Command.ExecuteScalar());

            }
            return result;
        }
        public List<Artist> GetArtistsWithSp(string nombre)
        {
            var artists = new List<Artist>();
            string CadenaConexion = "Data Source=.;Initial Catalog=Chinook; User ID=sa; Password=sql";
            //string CadenaConexion = "server=(local); database=Chinook; User Id=sa; Pwd=sql";

            //Creando un objeto Conexion
            using (var connection = new SqlConnection(CadenaConexion))
            {
                //Abriendo la conexion en la Base de Datos 
                connection.Open();
                var query = "usp_GetArtists";
                //Generando un objeto Command 
                var Command = new SqlCommand(query, connection);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                //Agregando Parametros
                Command.Parameters.AddWithValue("@FiltroByName", nombre);

                //Ejecutar el comando y  depositarlo en un DataReader
                var reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var artist = new Artist();
                        var indice = reader.GetOrdinal("Name");
                        artist.Name = reader.GetString(indice);
                        //artist.Name = (string)reader["Name"];
                        indice = reader.GetOrdinal("ArtistID");
                        artist.ArtistId = reader.GetInt32(indice);
                        //artist.ArtistId = (int)reader["ArtistId"];

                        //artist.ArtistId = reader.GetInt32(reader.GetOrdinal("ArtistId"));
                        //artist.Name     = reader.GetString(reader.GetOrdinal("Name"));

                        //Agregando a la Lista 
                        artists.Add(artist);
                    }
                }
            }
            return artists;
        }

        public List<Artist> GetArtists(string nombre)
        {
            var artists = new List<Artist>();
            //string CadenaConexion = "Data Source=.;Initial Catalog=Chinook; User ID=sa; Password=softpad01";
            string CadenaConexion = "server=(local); database=Chinook; User Id=sa; Pwd=sql";

            //Creando un objeto Conexion
            using (var connection = new SqlConnection(CadenaConexion))
            {
                //Abriendo la conexion en la Base de Datos 
                connection.Open();
                //var query = "Select * from Artist where [Name] like '%"+nombre+"%'";
                var query = "Select * from Artist where [Name] like @FiltroByName";
                //Generando un objeto Command 
                var Command = new SqlCommand(query, connection);
                Command.Parameters.AddWithValue("@FiltroByName", nombre);

                //Ejecutar el comando y  depositarlo en un DataReader
                var reader = Command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        var artist = new Artist();
                        var indice = reader.GetOrdinal("Name");
                        artist.Name = reader.GetString(indice);
                        //artist.Name = (string)reader["Name"];
                        indice = reader.GetOrdinal("ArtistID");
                        artist.ArtistId = reader.GetInt32(indice);
                        //artist.ArtistId = (int)reader["ArtistId"];

                        //artist.ArtistId = reader.GetInt32(reader.GetOrdinal("ArtistId"));
                        //artist.Name     = reader.GetString(reader.GetOrdinal("Name"));

                        //Agregando a la Lista 
                        artists.Add(artist);
                    }
                }
            }
            return artists;
        }
    }
}
