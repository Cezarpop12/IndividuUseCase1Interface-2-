using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutfitKing.Models;
using System.Diagnostics;

namespace OutfitKing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// De homepagina wordt getoond
        /// </summary>
        /// <returns>Return de view van de Homepagina</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// De privacy pagina wordt getoond
        /// </summary>
        /// <returns>Return de view van Privacy</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult OutfitToevoegen()
        {
            int? ID = HttpContext.Session.GetInt32("ID");
            if (ID != null)
            {
                return RedirectToAction("OutfitAanmaken", "Outfit");
            }
            return Content("Log eerst in!");
        }

        public IActionResult OnderdeelToevoegen()
        {
            int? ID = HttpContext.Session.GetInt32("ID");
            if (ID != null)
            {
                return RedirectToAction("OnderdeelAanmaken", "Onderdeel");
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