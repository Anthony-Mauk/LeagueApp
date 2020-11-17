namespace LeagueApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterNukeTeam : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Team", "CoachId", "dbo.Coach");
            DropIndex("dbo.Team", new[] { "CoachId" });
            DropTable("dbo.Team");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CoachId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateIndex("dbo.Team", "CoachId");
            AddForeignKey("dbo.Team", "CoachId", "dbo.Coach", "CoachId", cascadeDelete: true);
        }
    }
}
