﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTimer.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTimer.Controllers
{
    public class ProjectsController : Controller
    {
        ProjectsIndexVM projects = new ProjectsIndexVM();

        [Route("")]
        public IActionResult Index()
        {
            return View(projects);
          
        }
    }
}
