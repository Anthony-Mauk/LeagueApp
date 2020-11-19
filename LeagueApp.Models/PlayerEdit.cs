using LeagueApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Models
{
    public class PlayerEdit
    {
        public int PlayerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Parent Email")]
        public string ParentEmail { get; set; }

        public int TeamId { get; set; } // many players linked to the one table
        //[ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }
    }
}
