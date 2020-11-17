using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueApp.Models
{
    public class PlayerListItem
    {
        public int PlayerId { get; set; }
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentEmail { get; set; }
    }
}
