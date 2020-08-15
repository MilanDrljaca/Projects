using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projects.Models;
using Services.Interfaces;
using Services.Models;

namespace Projects.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjectService _projectService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProjectService projectService, ApplicationDbContext context)
        {
            _projectService = projectService;
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            ViewData["IdSortParm"] = sortOrder == "Id" ? "id_desc" : "Id";
            ViewData["ProjectNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "project_name" : "";
            ViewData["ManagerNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "manager_name" : "";
            ViewData["StartDateSortParm"] = sortOrder == "StartDate" ? "start_date_desc" : "StartDate";
            ViewData["EndDateSortParm"] = sortOrder == "EndDate" ? "end_date_desc" : "EndDate";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var projects = from s in _context.Projects
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(s => s.ProjectName.Contains(searchString)
                                       || s.ManagerName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "id_desc":
                    projects = projects.OrderByDescending(s => s.ID_Project);
                    break;
                case "project_name":
                    projects = projects.OrderBy(s => s.ProjectName);
                    break;
                case "manager_name":
                    projects = projects.OrderBy(s => s.ManagerName);
                    break;
                case "StartDate":
                    projects = projects.OrderBy(s => s.StartDate);
                    break;
                case "start_date_desc":
                    projects = projects.OrderByDescending(s => s.StartDate);
                    break;
                case "EndDate":
                    projects = projects.OrderBy(s => s.EndDate);
                    break;
                case "end_date_desc":
                    projects = projects.OrderByDescending(s => s.EndDate);
                    break;
                default:
                    projects = projects.OrderBy(s => s.ID_Project);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Project>.CreateAsync(projects.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([FromForm] CreateProjectRequest createProjectRequest)
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

            project = _projectService.Create(project);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_projectService.GetProjectByID(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            Project project = _projectService.GetProjectByID(id);
            _projectService.Delete(project);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_projectService.GetProjectByID(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.Projects.Where(p => p.ID_Project == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(int id, Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}



