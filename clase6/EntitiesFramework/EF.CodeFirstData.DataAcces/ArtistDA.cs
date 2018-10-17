using EF.CodeFirstData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF.CodeFirstData.DataAcces
{
    public class ArtistDA
    {
        private ChinookModel _context;

        public ArtistDA()
        {
            _context = new ChinookModel();
        }
        /// <summary>
        /// Obtiene la cantidad de Registros 
        /// </summary>
        /// <returns> Retorna un numero Entero </returns>
        public int Count()
        {
            //Utilizando Linq Para obtener la cantidad de registros
            return _context.Artist.Count();
        }
        /// <summary>
        /// Permite obtener los datos de un Artista
        /// </summary>
        /// <param name="id">Parametro de tipo Entero que representa el codigo del Artista</param>
        /// <returns>Retorna la informacion del Artista </returns>
        public Artist GetArtistById(int id)
        {
            return _context.Artist
                .Include(item=>item.Album.Select(item2 => item2.Track))
                .Where(item => item.ArtistId == id)
                .FirstOrDefault();
        }
        /// <summary>
        /// Obtiene el Listado de Artistas filtrado x nombre
        /// </summary>
        /// <param name="FiltroByName">Fitro x Nombre</param>
        /// <returns>Retorna lista de Artistas</returns>
        public IEnumerable<Artist> GetArtists(string FiltroByName)
        {
            return _context.Artist.Where(item => item.Name.Contains(FiltroByName)).ToList();
        }
        /// <summary>
        /// Inserta un registro en la tabla Artista
        /// </summary>
        /// <param name="artist">Entidad Artista</param>
        /// <returns>Retorna el codigo Generado</returns>
        public int InsertArtist(Artist artist)
        {
            _context.Artist.Add(artist);
            _context.SaveChanges();

            return artist.ArtistId;
        }
        public bool UpdateArtist(Artist artist)
        {
            _context.Artist.Attach(artist);
            _context.Entry(artist).State =System.Data.Entity.EntityState.Modified;

            return _context.SaveChanges()>0;
        }
        public bool DeleteArtist(Artist artist)
        {
            _context.Artist.Attach(artist);
            _context.Artist.Remove(artist);

            return _context.SaveChanges() > 0;
        }
    }
}
