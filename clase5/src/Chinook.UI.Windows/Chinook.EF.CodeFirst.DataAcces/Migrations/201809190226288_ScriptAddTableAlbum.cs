namespace Chinook.EF.CodeFirst.DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptAddTableAlbum : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Album", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Album", new[] { "ArtistID" });
            DropTable("dbo.Album");
        }
    }
}
