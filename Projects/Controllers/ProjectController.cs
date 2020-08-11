using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;
using DomainModel;

namespace Projects.Controllers
{
    public class ProjectController : Controller
    {

        private readonly IProjectService _iprojectService;

        public ProjectController(IProjectService iprojectService)
        {
            _iprojectService = iprojectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreateNewProject()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult CreateNewProject([FromForm] CreateProjectRequest createProjectRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Project project = new Project
            {
                ProjectName = createProjectRequest.ProjectName,
                ManagerName = createProjectRequest.ManagerName,
                StartDate = createProjectRequest.StartDate,
                EndDate = createProjectRequest.EndDate,
            };

            project = _iprojectService.Create(project);
            TempData["mydata"] = project.ProjectName;

            return RedirectToAction("Index", "Home");
        }
    }
}