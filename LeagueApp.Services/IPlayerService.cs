using LeagueApp.Models;
using System.Collections.Generic;

namespace LeagueApp.Services
{
    public interface IPlayerService
    {
        bool CreatePlayer(PlayerCreate model);
        bool DeletePlayer(int playerId);
        PlayerDetail GetPlayerById(int id);
        IEnumerable<PlayerListItem> GetPlayers();
        bool UpdatePlayer(PlayerEdit model);
    }
}