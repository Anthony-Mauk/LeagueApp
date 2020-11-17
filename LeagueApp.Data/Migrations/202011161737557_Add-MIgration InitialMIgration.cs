namespace LeagueApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMIgrationInitialMIgration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Team", "CoachId");
            DropColumn("dbo.Team", "PlayerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Team", "PlayerId", c => c.Int());
            AddColumn("dbo.Team", "CoachId", c => c.Int());
        }
    }
}
