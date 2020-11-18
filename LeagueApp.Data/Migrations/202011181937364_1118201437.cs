namespace LeagueApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1118201437 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coach", "TeamId", "dbo.Team");
            AddColumn("dbo.Coach", "Team_TeamId", c => c.Int());
            CreateIndex("dbo.Coach", "Team_TeamId");
            AddForeignKey("dbo.Coach", "Team_TeamId", "dbo.Team", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coach", "Team_TeamId", "dbo.Team");
            DropIndex("dbo.Coach", new[] { "Team_TeamId" });
            DropColumn("dbo.Coach", "Team_TeamId");
            AddForeignKey("dbo.Coach", "TeamId", "dbo.Team", "TeamId");
        }
    }
}
