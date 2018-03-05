using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimer.Models.ViewModels
{
    public class ProjectsCreateVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }
        
    }
}
