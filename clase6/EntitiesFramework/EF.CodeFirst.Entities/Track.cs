﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirst.Entities
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public int AlbumId { get; set; }

        public int GenreId { get; set; }

        //Relaciona el track con el Album
        public virtual Album Album { get; set; }

        //Relaciona el track con el Album
        public virtual Genre Genre { get; set; }

        //Relacion de muchos PlaylistTrack para un artista
        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}
