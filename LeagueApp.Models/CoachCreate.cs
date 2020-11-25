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
    public class CoachCreate
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Display(Name = "Team Id")]
        public int TeamId { get; set; } // many players linked to the one table - remove ? nullable
       // [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }
    }
}
