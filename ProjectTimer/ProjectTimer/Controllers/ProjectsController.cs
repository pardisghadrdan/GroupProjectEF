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
        ProjectsRepository repository;

        public ProjectsController(ProjectsRepository repository)
        {
            this.repository = repository;
        }


        [Route("")]
        public IActionResult Index()
        {
            return View(repository.GetProjects());
          
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

            repository.AddNewProjectVM(createProject);
            return RedirectToAction(nameof(Index));

        }

        [Route("Projects/Info/{id}")]
        [HttpGet]
        public IActionResult Info(int id)
        {
            return View(repository.GetProjectById(id));
        }

        [Route("Projects/ReportElapsedTime/{id}")]
        [HttpPost]
        public IActionResult Info(int id, string elapsedTime)
        {
            TimeSpan time = repository.UpdateProjectWithElapsedTime(id, elapsedTime);
            //ConvertTimeStringToIntArray(elapsedTime);


            return Content($"{time.Hours}:{time.Minutes}:{time.Seconds}");
        }
    }
}
