using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.EF.CodeFirst.Entities
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        //Relacion de muchos albumnes para un artista
        public virtual ICollection<Album> Album { get; set; }
    }
}
