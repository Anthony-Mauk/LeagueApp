using LeagueApp.Models;
using System.Collections.Generic;

namespace LeagueApp.Services
{
    public interface ICoachService
    {
        bool CreateCoach(CoachCreate model);
        bool DeleteCoach(int coachId);
        CoachDetail GetCoachById(int id);
        IEnumerable<CoachListItem> GetCoaches();
        bool UpdateCoach(CoachEdit model);
    }
}