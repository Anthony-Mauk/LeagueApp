namespace LeagueApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BeforeCountFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Team", "CoachCount", c => c.Int(nullable: false));
            AddColumn("dbo.Team", "PlayerCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Team", "PlayerCount");
            DropColumn("dbo.Team", "CoachCount");
        }
    }
}
