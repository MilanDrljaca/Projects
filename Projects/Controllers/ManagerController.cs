using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projects.Models;
using Services.Interfaces;
using Services.Models;

namespace Projects.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly ApplicationDbContext _context;

        public ManagerController(IManagerService managerService, ApplicationDbContext context)
        {
            _managerService = managerService;
            _context = context;
        }

       
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["Active"] = sortOrder == "Id" ? "id_desc" : "Id";
            ViewData["ManagerNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "manager_name" : "";
          
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var projects = from s in _context.Managers
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(s => s.ManagerName.Contains(searchString)
                                       || s.ManagerName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "id_desc":
                    projects = projects.OrderByDescending(s => s.Active);
                    break;

                case "manager_name":
                    projects = projects.OrderBy(s => s.ManagerName);
                    break;
               
                default:
                    projects = projects.OrderBy(s => s.ManagerName);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Manager>.CreateAsync(projects.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create([FromForm] CreateManagerRequest createManagerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Manager manager = new Manager
            {
            
                ManagerName = createManagerRequest.ManagerName,
                Active = 1,
                
            };

            manager = _managerService.CreateManager(manager);

            return RedirectToAction("Index", "Manager");
        }


        [HttpGet]
        public IActionResult Deactivate(string managerName)
        {
            return View(_managerService.GetManagerByManagerName(managerName));
        }

        [HttpPost]
        public IActionResult Deactivate(string managerName, IFormCollection collection)
        {
            Manager manager = _managerService.GetManagerByManagerName(managerName);
            _managerService.DeactivateManager(manager.ManagerName);
            return RedirectToAction("Index");
        }



        //[HttpGet]
        //public IActionResult Details(int id)
        //{
        //    return View(_projectService.GetProjectByID(id));
        //}
    }
}