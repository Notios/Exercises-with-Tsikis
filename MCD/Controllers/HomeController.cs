using MCD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MCD.Controllers
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
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(int num1, int num2)
        {
            int mcd = FindMaxCommonDivisor(num1, num2);
            ViewBag.num1 = num1;
            ViewBag.num2 = num2;
            ViewBag.MCD = mcd;
            return View("Index");
        }

        private int FindMaxCommonDivisor(int num1, int num2)
        {
            while (num2 != 0)
            {
                int temp = num2;
                num2 = num1 % num2;
                num1 = temp;
            }
            return num1;
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
