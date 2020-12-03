using LeagueApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Models
{
    public class TeamDetail
    {
        public int TeamId { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
        public ICollection<Coach> Coaches { get; set; } = new List<Coach>();

    }
}
