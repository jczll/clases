using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirst.Entities
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        //Relacion de PlayListtrack para un Playlist
        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}
