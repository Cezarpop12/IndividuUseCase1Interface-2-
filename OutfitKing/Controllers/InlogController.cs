using BusnLogicLaag;
using DALMSSQLSERVER;
using InterfaceLib;
using Microsoft.AspNetCore.Mvc;
using OutfitKing.Models;

namespace OutfitKing.Controllers
{
    /// <summary>
    /// Deze controller heeft verantw van inloggen, als de gebr is ingelogd activeer de sessie.
    /// </summary>
    public class InlogController : Controller
    {
        /// <summary>
        /// url = https/:localhost/{controller}/{action}/{id} ('pattern' in program.cs)
        /// </summary>

        private readonly ILogger<InlogController> _logger;
        public GebruikerContainer gebrContainer = new GebruikerContainer(new GebruikerMSSQLDAL());

        public InlogController(ILogger<InlogController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// IActionresult is een interface en actionresult is een implimentatie daarvan
        /// </summary>

        public ActionResult Index() 
        {
            GebruikerVM gebrVM = new GebruikerVM();
            gebrVM.Retry = false;
            return View(gebrVM);
        }

        /// <summary>
        /// Controleert gebrnaam en ww, indien correct sla op in de sessie
        /// </summary>
        /// <param name="gebruiker">Gebruikersnaam en ww die de gebr heeft ingetikt</param>
        /// <returns>Indien onbekend, terug naar dezelfde pagina, bekend = redirect naar de homepage </returns>
        [HttpPost]
        public IActionResult Index(GebruikerVM gebruiker)
        {       
            Gebruiker gebr = null;
            try
            {
                gebr = gebrContainer.ZoekGebrOpGebrnaamEnWW(gebruiker.Gerbuikersnaam, gebruiker.Wachtwoord);
            }
            catch (TemporaryExceptions ex)
            {
                return Content($"Er heeft een fout plaatsgevonden, probeer het in 5 minuten nog eens. " + ex.Message); 
            }
            catch (PermanentExceptions ex)
            {
                return Redirect("https://twitter.com/outfitservicestatus");
            }

            if (gebr != null) 
            {
                HttpContext.Session.SetInt32("ID", gebr.ID);
                return RedirectToAction("Index", "Home", gebruiker);
            }
            else
            {
                GebruikerVM gebrVM = new GebruikerVM();
                gebrVM.Retry = true;
                return View(gebrVM); 
            }
        }

        [HttpGet]
        public IActionResult Uitloggen()  
        {
            int? ID = HttpContext.Session.GetInt32("ID");
            if (ID != null)
            {
               HttpContext.Session.Clear();
               return Content("Uitgelogd!");
            }
            return Content("Geen gebruiker gevonden.");
        }

        [HttpGet]
        public ActionResult AccountAanmaken()  
        {
            GebruikerVM gebrVM = new GebruikerVM();
            gebrVM.Retry = false;
            return View(gebrVM);
        }
        
        [HttpPost]
        public IActionResult AccountAanmaken(GebruikerVM gebruiker)
        {
            Gebruiker gebr = null;
            try
            {
                gebr = gebrContainer.ZoekGebrOpGebrnaamOfAlias(gebruiker.Gerbuikersnaam, gebruiker.Alias);
            }
            catch (TemporaryExceptions ex)
            {
                return Content(ex.Message); 
            }
            catch (PermanentExceptions ex)
            {
                return Content(ex.Message);
            }
                
            if (gebr != null)
            {
                GebruikerVM gebrVM = new GebruikerVM();
                gebrVM.Retry = true;
                return View(gebrVM);
            }
            else
            {
                gebrContainer.CreateGebr(new Gebruiker(gebruiker.Gerbuikersnaam, gebruiker.Alias), gebruiker.Wachtwoord);
                return RedirectToAction("Index", "Home", gebruiker);
            }
        }
    }
}
