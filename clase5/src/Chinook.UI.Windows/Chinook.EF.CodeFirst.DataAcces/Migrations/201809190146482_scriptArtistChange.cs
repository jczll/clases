namespace Chinook.EF.CodeFirst.DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scriptArtistChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artist", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artist", "Name", c => c.String());
        }
    }
}
