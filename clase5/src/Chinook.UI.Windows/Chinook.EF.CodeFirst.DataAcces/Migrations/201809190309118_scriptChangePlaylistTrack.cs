namespace Chinook.EF.CodeFirst.DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scriptChangePlaylistTrack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Track", "AlbumId", c => c.Int(nullable: false));
            CreateIndex("dbo.Track", "AlbumId");
            AddForeignKey("dbo.Track", "AlbumId", "dbo.Album", "AlbumId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Track", "AlbumId", "dbo.Album");
            DropIndex("dbo.Track", new[] { "AlbumId" });
            DropColumn("dbo.Track", "AlbumId");
        }
    }
}
