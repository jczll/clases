namespace EF.CodeFirst.DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scriptInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ArtistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Artist", t => t.ArtistID, cascadeDelete: true)
                .Index(t => t.ArtistID);
            
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        AlbumId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.AlbumId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.PlaylistTrack",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlaylistId, t.TrackId })
                .ForeignKey("dbo.Playlist", t => t.PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Track", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.PlaylistId)
                .Index(t => t.TrackId);
            
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.PlaylistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaylistTrack", "TrackId", "dbo.Track");
            DropForeignKey("dbo.PlaylistTrack", "PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.Track", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Track", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Album", "ArtistID", "dbo.Artist");
            DropIndex("dbo.PlaylistTrack", new[] { "TrackId" });
            DropIndex("dbo.PlaylistTrack", new[] { "PlaylistId" });
            DropIndex("dbo.Track", new[] { "GenreId" });
            DropIndex("dbo.Track", new[] { "AlbumId" });
            DropIndex("dbo.Album", new[] { "ArtistID" });
            DropTable("dbo.Playlist");
            DropTable("dbo.PlaylistTrack");
            DropTable("dbo.Genre");
            DropTable("dbo.Track");
            DropTable("dbo.Artist");
            DropTable("dbo.Album");
        }
    }
}
