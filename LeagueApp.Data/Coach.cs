using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Data
{
    public class Coach
    {
        [Key]
        public int CoachId { get; set; } 
        
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [ForeignKey(nameof(Team))]  // added this line and commented 27
        public int TeamId { get; set; } //many linked to the one table
        //[ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }



    }
}
