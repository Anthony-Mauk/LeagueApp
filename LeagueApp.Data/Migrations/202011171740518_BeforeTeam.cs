namespace LeagueApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BeforeTeam : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Coach", t => t.CoachId, cascadeDelete: true)
                .Index(t => t.CoachId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Team", "CoachId", "dbo.Coach");
            DropIndex("dbo.Team", new[] { "CoachId" });
            DropTable("dbo.Team");
        }
    }
}
