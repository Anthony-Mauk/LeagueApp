namespace LeagueApp.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    
    internal sealed class Configuration : DbMigrationsConfiguration<LeagueApp.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LeagueApp.Data.ApplicationDbContext";
        }

        protected override void Seed(LeagueApp.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            context.Teams.AddOrUpdate(
                p => p.Name,
                new Team() { OwnerId = Guid.Parse(context.Users.Single(e=>e.UserName == "seeduser@mail.com").Id),
                Name = "Beasts", TeamId =1 },
                new Team() { OwnerId = Guid.Parse(context.Users.Single(e=>e.UserName == "seeduser@mail.com").Id),
                Name = "Cavaliers", TeamId =2 },
                new Team()
                {
                    OwnerId = Guid.Parse(context.Users.Single(e => e.UserName == "seeduser@mail.com").Id),
                    Name = "Jumpers",
                    TeamId = 3
                },
                new Team()
                {
                    OwnerId = Guid.Parse(context.Users.Single(e => e.UserName == "seeduser@mail.com").Id),
                    Name = "Lakers",
                    TeamId = 4
                },
                new Team()
                {
                    OwnerId = Guid.Parse(context.Users.Single(e => e.UserName == "seeduser@mail.com").Id),
                    Name = "Pistons",
                    TeamId = 5
                });

            //context.Players.AddOrUpdate(
            //    p => p.PlayerId,
            //    new Player()
            //    {
            //        OwnerId = Guid.Parse(context.Users.Single(e => e.UserName == "seeduser@mail.com").Id),
            //        FirstName = "Andy",
            //        LastName = "Albert",
            //        ParentEmail = "albert@mail.com",
            //        PlayerId = 1
            //    },

            //    );

        }
    }
}
