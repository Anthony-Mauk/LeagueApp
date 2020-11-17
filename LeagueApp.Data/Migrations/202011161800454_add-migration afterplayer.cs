namespace LeagueApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationafterplayer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Coach", "TeamId");
            DropColumn("dbo.Coach", "PlayerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coach", "PlayerId", c => c.Int());
            AddColumn("dbo.Coach", "TeamId", c => c.Int());
        }
    }
}
