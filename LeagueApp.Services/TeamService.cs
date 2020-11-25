using LeagueApp.Data;
using LeagueApp.Models;
using Sentry;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Services
{
    public class TeamService : ITeamService
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
                //List<Player> player = new List<Player>();

                var query =
                    ctx
                        .Teams
                        .Include(nameof(Coach))
                        .Include(nameof(Player))
                        .Where(e => e.OwnerId == _userId)
                        // add next two lines
                        //.Include(e => e.Coaches) // added this
                        //.Include(e => e.Players) // added this
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    TeamId = e.TeamId,
                                    Name = e.Name,
                                    Coaches = e.Coaches,
                                    Players = e.Players,
                                    //PlayerCount = player.Count,
                                    PlayerCount = e.Players.Count,
                                    CoachCount = e.Coaches.Count
                                }
                        );

                //var query = from team in ctx.Teams
                //            where team.OwnerId == _userId
                //            join coach in ctx.Coaches on team.TeamId equals coach.TeamId
                //            join player in ctx.Players on team.TeamId equals player.TeamId
                //            select new TeamListItem
                //            {
                //                TeamId = team.TeamId,
                //                Name = team.Name,
                //                Coaches = team.Coaches,
                //                Players = team.Players,
                //                PlayerCount = team.Players.Count(),
                //                CoachCount = team.Coaches.Count
                //            };

                return query.ToArray();
            }
        }

        //private int GetPlayerCount(ICollection<Player> players)
        //{
        //    int count = 0;

        //    foreach (Player player in players)
        //    {
        //        count++;
        //    }
        //    return count;
        //}
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

                if (entity.Coaches.Count > 0 || entity.Players.Count > 0)
                {

                    return false;
                }
                else
                {
                    ctx.Teams.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }

            }

        }
    }
}
