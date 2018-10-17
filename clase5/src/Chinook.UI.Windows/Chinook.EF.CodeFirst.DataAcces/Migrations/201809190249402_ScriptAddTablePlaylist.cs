namespace Chinook.EF.CodeFirst.DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptAddTablePlaylist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.PlaylistId);
            
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
                "dbo.Track",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.TrackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaylistTrack", "TrackId", "dbo.Track");
            DropForeignKey("dbo.PlaylistTrack", "PlaylistId", "dbo.Playlist");
            DropIndex("dbo.PlaylistTrack", new[] { "TrackId" });
            DropIndex("dbo.PlaylistTrack", new[] { "PlaylistId" });
            DropTable("dbo.Track");
            DropTable("dbo.PlaylistTrack");
            DropTable("dbo.Playlist");
        }
    }
}
