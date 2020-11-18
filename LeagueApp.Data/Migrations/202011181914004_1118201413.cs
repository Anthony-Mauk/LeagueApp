namespace LeagueApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1118201413 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            AddColumn("dbo.Player", "Team_TeamId", c => c.Int());
            CreateIndex("dbo.Player", "Team_TeamId");
            AddForeignKey("dbo.Player", "Team_TeamId", "dbo.Team", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "Team_TeamId", "dbo.Team");
            DropIndex("dbo.Player", new[] { "Team_TeamId" });
            DropColumn("dbo.Player", "Team_TeamId");
            AddForeignKey("dbo.Player", "TeamId", "dbo.Team", "TeamId");
        }
    }
}
