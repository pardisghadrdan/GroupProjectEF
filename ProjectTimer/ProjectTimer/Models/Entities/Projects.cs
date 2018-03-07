using System;
using System.Collections.Generic;

namespace ProjectTimer.Models.Entities
{
    public partial class Projects
    {
        public Projects()
        {
            Sessions = new HashSet<Sessions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Milliseconds { get; set; }

        public ICollection<Sessions> Sessions { get; set; }
    }
}
