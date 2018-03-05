using ProjectTimer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimer.Models
{
    public class ProjectsRepository
    {
        public static ProjectsIndexVM temp = new ProjectsIndexVM();


        public void AddNewProjectVM(ProjectsCreateVM create)
        {
            temp.ProjectList.Add(new ProjectsIndexVM.ProjectVM
            {
                Id = ++ProjectsIndexVM.projectId,
                ProjectName = create.Name,
                ProjectLength = new TimeSpan(0, 0, 0)
            });
        }
        public ProjectsIndexVM GetProjects()
        {
            return temp;
        }
    }
}
