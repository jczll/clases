using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirst.Entities
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [StringLength(120)]
        public string Name { get; set; }

        //Relacion de muchos Track para un artista
        public virtual ICollection<Track> Track { get; set; }
    }
}
