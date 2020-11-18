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
        [Key]
        public int TeamId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name="Team Name")]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; } = new List<Player>(); // one table holding the many entities
        

        public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>(); // one table holding the many entities
    }
}
