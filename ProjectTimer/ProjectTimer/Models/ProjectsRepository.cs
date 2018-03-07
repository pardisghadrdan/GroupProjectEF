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
                ProjectLength = new TimeSpan(0, 0, 0),
                Category = create.Category
            });
        }
        public ProjectsIndexVM GetProjects()
        {
            return temp;
        }

        public ProjectsInfoVM GetProjectById(int id)
        {
            var project = temp.ProjectList.Single(p => p.Id == id);
            return new ProjectsInfoVM { Id = project.Id, Category = project.Category, Name = project.ProjectName, TotalTime = project.ProjectLength };
        }

        public int[] ConvertTimeStringToIntArray(string time)
        {
            int[] array = new int[3];
            string[] stringArray = time.Split(":");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(stringArray[i]);
            }
            
            return array;
        }

        internal void UpdateProjectWithElapsedTime(int id, string elapsedTime)
        {
        }
    }
}
