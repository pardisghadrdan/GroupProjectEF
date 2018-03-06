using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimer.Models.ViewModels
{
    public class ProjectsIndexVM
    {
        public static int projectId = 0;

        public ProjectsIndexVM()
        {
            ProjectList = new List<ProjectVM>
            {

                new ProjectVM {Id=++projectId, ProjectName="Projekt1", Category="work",ProjectLength=new TimeSpan(0, 0, 10) },
                new ProjectVM {Id=++projectId, ProjectName="Projekt2", Category="play",ProjectLength=new TimeSpan(0, 0, 20) },
                new ProjectVM {Id=++projectId, ProjectName="Projekt3", Category="training",ProjectLength=new TimeSpan(0, 0, 10) }
            };                                                        
        }


        public List<ProjectVM> ProjectList { get; set; }

        public class ProjectVM
        {
            public int Id { get; set; }
            public string ProjectName { get; set; }
            public string Category { get; set; }
            public TimeSpan ProjectLength { get; set; }

        }
    }
}
