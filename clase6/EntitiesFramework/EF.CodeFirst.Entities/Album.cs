using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirst.Entities
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public int ArtistID { get; set; }

        //Relaciona el Album con el Artista
        public virtual Artist Artist { get; set; }
        //Relacion de muchos Track para un artista
        public virtual ICollection<Track> Track { get; set; }
    }
}
