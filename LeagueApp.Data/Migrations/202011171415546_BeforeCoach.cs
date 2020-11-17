namespace LeagueApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BeforeCoach : DbMigration
    {
        public override void Up()
        {
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
                        Mascot = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId);
            
        }
    }
}
