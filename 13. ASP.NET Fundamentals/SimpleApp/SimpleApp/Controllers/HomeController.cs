using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
using System.Diagnostics;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hi Brother!";

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Numbers(int count = 10)
        {
            ViewBag.Count = count;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}