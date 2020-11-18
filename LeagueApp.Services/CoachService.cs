using LeagueApp.Data;
using LeagueApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Services
{
    public class CoachService
    {
        private readonly Guid _userId;
        public CoachService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCoach(CoachCreate model)
        {
            var entity =
                new Coach()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    TeamId = model.TeamId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Coaches.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CoachListItem> GetCoaches()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Coaches
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CoachListItem
                                {
                                    CoachId = e.CoachId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Email = e.Email,
                                    TeamId = e.TeamId
                                }
                        );

                return query.ToArray();
            }
        }

        public CoachDetail GetCoachById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Coaches
                        .Single(e => e.CoachId == id && e.OwnerId == _userId);
                return new CoachDetail
                {
                    CoachId = entity.CoachId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    TeamId = entity.TeamId
                };
            }
        }

        public bool UpdateCoach(CoachEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Coaches
                        .Single(e => e.CoachId == model.CoachId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.TeamId = model.TeamId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCoach(int coachId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Coaches
                        .Single(e => e.CoachId == coachId && e.OwnerId == _userId);

                ctx.Coaches.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
