using LeagueApp.Data;
using LeagueApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Services
{
    public class PlayerService
    {
        private readonly Guid _userId;

        public PlayerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlayer(PlayerCreate model)
        {
            var entity =
                new Player()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ParentEmail = model.ParentEmail,
                    TeamId = model.TeamId,
                    Team = model.Team
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlayerListItem> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PlayerListItem
                                {
                                    PlayerId = e.PlayerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    ParentEmail = e.ParentEmail,
                                    TeamId = e.TeamId
                                }
                        );

                return query.ToArray();
            }
        }

        public PlayerDetail GetPlayerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == id && e.OwnerId == _userId);
                return
                    new PlayerDetail
                    {
                        PlayerId = entity.PlayerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        ParentEmail = entity.ParentEmail,
                        TeamId = entity.TeamId,
                        Team = entity.Team
                    };
            }
        }
        public bool UpdatePlayer(PlayerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == model.PlayerId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.ParentEmail = model.ParentEmail;
                entity.TeamId = model.TeamId;
                entity.Team = model.Team;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlayer(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == playerId && e.OwnerId == _userId);

                ctx.Players.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
