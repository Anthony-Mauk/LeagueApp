using LeagueApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Models
{
    public class TeamListItem
    {
        [Display(Name = "Team Id")]
        public int TeamId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Coach Id")]
        public int CoachId { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; } = new HashSet<Coach>(); //took off Hashset from data and model
        public int PlayerId { get; set; }
        public virtual ICollection<Player> Players { get; set; } = new HashSet<Player>();
        [Display(Name ="# of Coaches")]
        public int CoachCount { get; set; }
        [Display(Name = "# of Players")]
        public int PlayerCount { get; set; }
        //public int CoachCount
        //{
        //    get
        //    {
        //        return Coaches.Count();
        //    }
        //    set { }
        //}
        
        //public int PlayerCount
        //{
        //    get
        //    {
        //        return Players.Count();
        //    }
        //    set { }

        //}
    }
}
