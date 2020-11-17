namespace LeagueApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Player", "TeamId");
            DropColumn("dbo.Player", "CoachId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Player", "CoachId", c => c.Int());
            AddColumn("dbo.Player", "TeamId", c => c.Int());
        }
    }
}
