using EF.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirst.DataAcces
{
    public class DataAcces:DbContext
    {
        public DataAcces() : base("Data Source=.;" +
                                    "Initial Catalog=ChinookEF; " +
                                    "User ID=sa; Password=softpad01")
        {

        }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<PlaylistTrack> PlaylistTrack { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
