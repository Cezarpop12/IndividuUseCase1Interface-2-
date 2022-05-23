using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutfitKing.Models;
using System.Diagnostics;

namespace OutfitKing.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Controllers zijn classes die luisteren naar de url die je intikt
        /// </summary>
        
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// (ILogger<HomeController> logger) = dependency injection. 
        /// Een object hangt af van een ander object. Je geeft het object de objecten mee die hij nodig heeft
        /// https://www.tutorialspoint.com/explain-dependency-injection-in-chash
        /// </summary>

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Toevoegen()
        {
            int? ID = HttpContext.Session.GetInt32("ID");
            if (ID != null)
            {
                return RedirectToAction("OutfitAanmaken", "Toevoeg");
            }
            return Content("Log eerst in!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}