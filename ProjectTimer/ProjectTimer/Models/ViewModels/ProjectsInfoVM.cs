using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimer.Models.ViewModels
{
    public class ProjectsInfoVM
    {
        public int Id { get; set; }

        [Display(Name="Category: ")]
        public string Category { get; set; }

        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Display(Name = "Total project time: ")]
        public TimeSpan TotalTime { get; set; }
    }
}
