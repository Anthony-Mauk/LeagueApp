using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Data
{
    public class Team
    {
        //[Key]
        //public int TeamId { get; set; }
        //public Guid OwnerId { get; set; }
        //[Required]
        //public string Name { get; set; }

        ////A team has one coach
        //[ForeignKey(nameof(Coach))]
        //public int CoachId { get; set; }
        //public virtual Coach Coach { get; set; }

        ////a team has many players
        //[ForeignKey(nameof(Player))]
        //public int PlayerId { get; set; }
        //public virtual ICollection<Player> Players { get; set; } //= new hashset<player>();

    }
}
