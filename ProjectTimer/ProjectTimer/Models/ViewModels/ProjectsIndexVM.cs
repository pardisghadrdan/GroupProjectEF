using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimer.Models.ViewModels
{
    public class ProjectsIndexVM
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Category { get; set; }
        public TimeSpan ProjectLength { get; set; }
    }    
}
