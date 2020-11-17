using LeagueApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Models
{
    public class TeamListItem
    {
        public int TeamId { get; set; }
        public string Name { get; set; }

        //A team has one coach
        public int CoachId { get; set; }
        public virtual Coach Coaches { get; set; }
        public int PlayerId { get; set; }
        public virtual ICollection<Player> Players { get; set; } //= new HashSet<Player>();
    }
}
