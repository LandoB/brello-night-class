using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Brello.Models
{
    public class BoardContext : DbContext
    {

        // We use this to create our tables, and then get and set data from those tables
        public virtual IDbSet<Color> Colors { get; set; }
        public virtual IDbSet<Card> Cards { get; set; }

    }

    
}