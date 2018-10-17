using Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArtistRepository : DataBase
    {
        public List<Artist> GetArtists(string nombre)
        {
            var artists = new List<Artist>();

            /*1. Creando un objeto connection*/
            using (var connection = this.CreateConnection())
            {
                //abriendo la conexion a la base de datos
                connection.Open();

                /* 2. - Creando un objeto Command*/
                var query = "SELECT Name, ArtistId FROM Artist WHERE Name LIKE @FiltroByName ";
                var command = new SqlCommand(query,(SqlConnection)connection);

                //Agregando un parametros
                command.Parameters.AddWithValue("@FiltroByName", nombre);

                //3. ejecutando el comando y recepcionado
                //el resultado en un Reader
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var artist = new Artist();
                        var indice = reader.GetOrdinal("Name");
                        artist.Name = reader.GetString(indice); //Es optimo
                        //artist.Name = (String)reader["Name"]; //No es optimo

                        indice = reader.GetOrdinal("ArtistId");
                        artist.ArtistId = reader.GetInt32(indice); //Es optimo
                        //artist.ArtistId = (int)reader["ArtistId"];//No es optimo

                        //Agregandolo a la lista
                        artists.Add(artist);
                    }
                }

            }
            return artists;
        }
        public List<Artist> GetArtistsWithSP(
           string nombre
           )
        {
            var artists = new List<Artist>();

            /*1. Creando un objeto connection*/
            using (var connection = this.CreateConnection())
            {
                //abriendo la conexion a la base de datos
                connection.Open();

                /* 2. - Creando un objeto Command*/
                var query = "usp_GetArtists";
                var command = new SqlCommand(query,
                                connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                //Agregando un parametros
                command.Parameters.AddWithValue("@FiltroByName", nombre);

                //3. ejecutando el comando y recepcionado
                //el resultado en un Reader
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var artist = new Artist();
                        var indice = reader.GetOrdinal("Name");
                        artist.Name = reader.GetString(indice); //Es optimo
                        //artist.Name = (String)reader["Name"]; //No es optimo

                        indice = reader.GetOrdinal("ArtistId");
                        artist.ArtistId = reader.GetInt32(indice); //Es optimo
                        //artist.ArtistId = (int)reader["ArtistId"];//No es optimo
                        //Agregandolo a la lista
                        artists.Add(artist);
                    }
                }
            }
            return artists;
        }

        public int InsertArtist(Artist artist)
        {
            int result = 0;
            using (var connection = this.CreateConnection())
            {
                connection.Open();

                var command = new SqlCommand("usp_InsertArtist", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", artist.Name);

                result = Convert.ToInt32(command.ExecuteScalar());
            }


            return result;
        }

        //Insertar artista dentro de un bloque de transacción
        public int InsertArtistTX(Artist artist)
        {
            int result = 0;

            using (var connection = this.CreateConnection())
            {
                connection.Open();

                //Iniciando la transaccion
                var transaction = connection.BeginTransaction();


                var command = new SqlCommand("usp_InsertArtist", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                //Asociando al objeto command la transaccion incializada en la linea 151
                command.Transaction = transaction;
                command.Parameters.AddWithValue("@Name", artist.Name);

                try
                {
                    result = Convert.ToInt32(command.ExecuteScalar());
                    //throw new Exception("Se cayo el sistema");
                    //Confirmando la transaccion
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    result = -1;
                    //Se realiza un rollback de los cambios realizados
                    transaction.Rollback();
                }
            }
            return result;
        }
        public bool DeleteArtist(int Id)
        {
            bool result = false;

            using (var connection = this.CreateConnection())
            {
                //El metodo Execute ejeucta el comando en la base de datos y devuelva la cantidad de registros que fueron afectados
                //en la ejecucion de ese comando
                result = connection.Execute("usp_DeleteArtist", new { ArtistID = Id }, commandType: CommandType.StoredProcedure) > 0;
            }

            return result;
        }
    }
}
