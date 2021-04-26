using CalculatorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(Calculator calculator)
        {
            return View(calculator);
        }

        [HttpPost]
        public IActionResult Calculator(Calculator calculator)
        {
            calculator.CalculateResult();

            return RedirectToAction("Index", calculator);
        }
    }
}
