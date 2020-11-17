using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Models
{
    public class PlayerCreate
    {
        //[Required]
        //public Guid OwnerId { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Parent Email")]
        public string ParentEmail { get; set; }
        //public int? TeamId { get; set; }
        //public int? CoachId { get; set; }
    }
}
