using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projects.Models;
using Services.Interfaces;

namespace Projects.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IProjectService projectService, ApplicationDbContext context)
        {
            _projectService = projectService;
            _logger = logger;
            _context = context;
        }

        //public ViewResult Index()
        //{
        //    var model = _projectService.GetAllProjects();
        //    return View(model);
        //}

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString ,int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["ProjectNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "project_name_desc" : "project_name_asc";
            ViewData["StartDateSortParm"] = sortOrder == "Date" ? "start_date_desc" : "StartDate";
            ViewData["EndDateSortParm"] = sortOrder == "Date" ? "end_date_desc" : "EndDate";
            ViewData["ManagerNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "manager_name_desc" : "manager_name_asc";
            //var projects = _projectService.GetAllProjects().AsQueryable();
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
                case "project_name_desc":
                    projects = projects.OrderByDescending(s => s.ProjectName);
                    break;
                case "project_name_asc":
                    projects = projects.OrderBy(s => s.ProjectName);
                    break;
                case "manager_name_asc":
                    projects = projects.OrderBy(s => s.ManagerName);
                    break;
                case "manager_name_desc":
                    projects = projects.OrderByDescending(s => s.ManagerName);
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
