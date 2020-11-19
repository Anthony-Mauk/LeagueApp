using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Data
{
    public class Team
    {
        //[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public Team()
        //{
        //    Players = new HashSet<Player>();
        //    Coaches = new HashSet<Coach>();
        //}

        [Key]
        public int TeamId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name="Team Name")]
        public string Name { get; set; }

        //[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Player> Players { get; set; } = new List<Player>(); // one table holding the many entities

        //[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>(); // one table holding the many entities

        public int CoachCount
        {
            get
            {

                return Coaches.Count;
            }
            set { }
        }
        
        public int PlayerCount
        {
            get
            {
                return Players.Count();
            }
            set { }

        }
    }
}
