using System;
using System.Collections.Generic;

namespace ProjectTimer.Models.Entities
{
    public partial class Sessions
    {
        public int Id { get; set; }
        public int ProjectsId { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Milliseconds { get; set; }

        public Projects Projects { get; set; }
    }
}
