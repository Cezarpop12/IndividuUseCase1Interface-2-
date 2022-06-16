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
        /// <returns>Return de view van de Homepagina met 4 outfits en 4 onderdelen (de laatste)</returns>
        public IActionResult Index()
        {
            try
            {
                OutEnOnderVM vm = new OutEnOnderVM();
                vm.Outfits = outfitContainer.GetLast4Outfits();
                vm.Onderdelen = onderdeelContainer.GetLast4Onderdelen();
                return View(vm);
            }
            catch (TemporaryExceptions ex)
            {
                return View("SqlErrorMessage");
            }
            catch (PermanentExceptions ex)
            {
                return View("PermanentError");
            }
        }

        /// <summary>
        /// De privacy pagina wordt getoond
        /// </summary>
        /// <returns>Return de view van Privacy</returns>
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