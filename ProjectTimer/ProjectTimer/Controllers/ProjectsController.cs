using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTimer.Models;
using ProjectTimer.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTimer.Controllers
{
    public class ProjectsController : Controller
    {
        ProjectsRepository projects = new ProjectsRepository();

        [Route("")]
        public IActionResult Index()
        {
            return View(projects.GetProjects());
          
        }

        [Route("Projects/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [Route("Projects/Create")]
        [HttpPost]
        public IActionResult Create(ProjectsCreateVM createProject)
        {
            if (!ModelState.IsValid)
                return View(createProject);

            projects.AddNewProjectVM(createProject);
            return RedirectToAction(nameof(Index));

        }

        [Route("Projects/Info/{id}")]
        [HttpGet]
        public IActionResult Info(int id)
        {
            return View(projects.GetProjectById(id));
        }

        [Route("Projects/ReportElapsedTime/{id}")]
        [HttpPost]
        public IActionResult Info(int id, string elapsedTime)
        {
            //projects.UpdateProjectWithElapsedTime(id, elapsedTime);
            projects.ConvertTimeStringToIntArray(elapsedTime);
            return Content("01:02:03");
        }
    }
}
