using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimer.Models.ViewModels
{
    public class ProjectsIndexVM
    {
        public ProjectsIndexVM()
        {
            ProjectList = new List<ProjectVM>
            {
                new ProjectVM {Id=1, ProjectName="Projekt1", ProjectLength=new TimeSpan(0, 0, 10) },
                new ProjectVM {Id=2, ProjectName="Projekt2", ProjectLength=new TimeSpan(0, 0, 20) },
                new ProjectVM {Id=3, ProjectName="Projekt3", ProjectLength=new TimeSpan(0, 0, 10) }
            };
        }

        public List<ProjectVM> ProjectList { get; set; }

        public class ProjectVM
        {
            public int Id { get; set; }
            public string ProjectName { get; set; }
            public TimeSpan ProjectLength { get; set; }

        }
    }
}
