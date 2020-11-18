using LeagueApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Models
{
    public class PlayerListItem
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentEmail { get; set; }

        public int? TeamId { get; set; } // many players linked to the one table
        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }
    }
}
