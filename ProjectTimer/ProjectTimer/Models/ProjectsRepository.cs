using ProjectTimer.Models.Entities;
using ProjectTimer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimer.Models
{
    public class ProjectsRepository
    {
        private readonly ProjectTimerContext context;
     
        public ProjectsRepository(ProjectTimerContext context)
        {
            this.context = context;
        }

        //public static ProjectsIndexVM temp = new ProjectsIndexVM();

        public void AddNewProjectVM(ProjectsCreateVM create)
        {

            context.Add(new Projects
            {
                Name = create.Name,
                 Hours = 0,
                  Minutes = 0,
                  Seconds = 0,
                  Milliseconds = 0,
                Category = create.Category
                 
                 
            });

            context.SaveChanges();
        }
        public ProjectsIndexVM[] GetProjects()
        {
            var projects = context.Projects.ToArray();
            return context.Projects
                  .OrderBy(p => p.Name)
                  .Select(p => new ProjectsIndexVM
                  {
                      Id = p.Id,
                      ProjectName = p.Name,
                      Category = p.Category,
                      ProjectLength = new TimeSpan(0,0,0)
                  }).ToArray();
        }

        public ProjectsInfoVM GetProjectById(int id)
        {
            var project = context.Projects.Single(p => p.Id == id);
            return new ProjectsInfoVM { Id = project.Id, Category = project.Category, Name = project.Name, TotalTime = new TimeSpan(project.Hours, project.Minutes, project.Seconds) };
        }

        public static int[] ConvertTimeStringToIntArray(string time)
        {
            int[] array = new int[3];
            string[] stringArray = time.Split(":");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(stringArray[i]);
            }
            
            return array;
        }

        //public static string ConvertIntArrayToTimeString(int[] times)
        //{


        //}

        public TimeSpan UpdateProjectWithElapsedTime(int id, string elapsedTime)
        {
            int[] totalTimeDB = this.GetTotalTimeDB(id);
            int[] lastSessionTime = ConvertTimeStringToIntArray(elapsedTime);
            int[] newTotalTime = AddLastSessionTimeToProject(lastSessionTime, totalTimeDB);

            //update Projects table
            Projects project = context.Projects.Find(id);
            project.Hours = newTotalTime[0];
            project.Minutes = newTotalTime[1];
            project.Seconds = newTotalTime[2];

            //update Sessions table
            context.Sessions.Add(new Sessions
            {
                ProjectsId = id,
                Hours = 0,
                Minutes = lastSessionTime[0],
                Seconds = lastSessionTime[1],
                Milliseconds = lastSessionTime[2]
            });
            context.SaveChanges();
            return new TimeSpan(newTotalTime[0], newTotalTime[1], newTotalTime[2]);
        }

        public int[] GetTotalTimeDB(int id)
        {
            Projects project = context.Projects.Find(id);
            int[] array = {project.Hours,project.Minutes,project.Seconds };
            return array;
        }

        public static int[] AddLastSessionTimeToProject(int [] sessionTime, int[] totalTime)
        {
            int[] newTotalTime = { 0,0,0};

            int seconds = sessionTime[1] + totalTime[2];
            if (seconds > 59)
            {
                newTotalTime[2] = seconds - 60;
                newTotalTime[1] = 1;
            }
            else
                newTotalTime[2] = seconds;

            int minutes = sessionTime[0] + totalTime[1];
            if (minutes > 59)
            {
                newTotalTime[1] += minutes - 60;
                newTotalTime[0] = 1;
            }
            else
                newTotalTime[1] = minutes;

            //add hours
            newTotalTime[0] += totalTime[0];

            return newTotalTime;
        }
    }
}
