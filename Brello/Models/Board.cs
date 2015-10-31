using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brello.Models
{
    public class Board
    {
        public int BoardId { get; set; }
        public int Title { get; set; }

        // Assigned To
        public virtual ICollection<BrelloList> Lists { get; set; }
        // Vote mechanism
        public virtual ICollection<ApplicationUser> Followers { get; set; }
    }
}