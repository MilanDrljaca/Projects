using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projects.Models;
using Services.Interfaces;

namespace Projects.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProjectService projectService)
        {
            _projectService = projectService;
            _logger = logger;
        }

        public ViewResult Index()
        {
            var model = _projectService.GetAllProjects();
            return View(model);
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
