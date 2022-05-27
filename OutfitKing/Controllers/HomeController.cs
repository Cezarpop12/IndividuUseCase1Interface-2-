using BusnLogicLaag;
using DALMSSQLSERVER;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutfitKing.Models;
using System.Diagnostics;

namespace OutfitKing.Controllers
{
    public class HomeController : Controller
    {
        public OutfitContainer outfitContainer = new OutfitContainer(new OutfitMSSQLDAL());
        public OnderdeelContainer onderdeelContainer = new OnderdeelContainer(new OnderdeelMSSQLDAL());
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
            OutEnOnderVM vm = new OutEnOnderVM();
            vm.Outfits = outfitContainer.GetLast4Outfits();
            vm.Onderdelen = onderdeelContainer.GetLast4Onderdelen();
            return View(vm);
        }

        /// <summary>
        /// De privacy pagina wordt getoond
        /// </summary>
        /// <returns>Return de view van Privacy</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult OutfitToevoegenRedirect()
        {
            int? ID = HttpContext.Session.GetInt32("ID");
            if (ID != null)
            {
                return RedirectToAction("OutfitAanmaken", "Outfit");
            }
            return Content("Log eerst in!");
        }

        public IActionResult OnderdeelToevoegenRedirect()
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