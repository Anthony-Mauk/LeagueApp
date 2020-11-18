using LeagueApp.Data;
using LeagueApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Services
{
    public class TeamService
    {
        private readonly Guid _userId;

        public TeamService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTeam(TeamCreate model)
        {
            var entity =
                new Team()
                {
                    OwnerId = _userId,
                    Name = model.Name
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    TeamId = e.TeamId,
                                    Name = e.Name
                                }
                        );
                return query.ToArray();
            }
        }
        public TeamDetail GetTeamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == id && e.OwnerId == _userId);
                return
                    new TeamDetail
                    {
                        TeamId = entity.TeamId,
                        Name = entity.Name
                    };
            }
        }

        public bool UpdateTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Teams.Single(e => e.TeamId == model.TeamId && e.OwnerId == _userId);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeam(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == teamId && e.OwnerId == _userId);

                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
