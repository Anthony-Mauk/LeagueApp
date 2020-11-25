using LeagueApp.Models;
using System.Collections.Generic;

namespace LeagueApp.Services
{
    public interface ITeamService
    {
        bool CreateTeam(TeamCreate model);
        bool DeleteTeam(int teamId);
        TeamDetail GetTeamById(int id);
        IEnumerable<TeamListItem> GetTeams();
        bool UpdateTeam(TeamEdit model);
    }
}