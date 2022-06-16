using BusnLogicLaag;
using DALMSSQLSERVER;
using InterfaceLib;
using Microsoft.AspNetCore.Mvc;
using OutfitKing.Models;

namespace OutfitKing.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        public GebruikerContainer gebrContainer = new GebruikerContainer(new GebruikerMSSQLDAL());

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// geeft een log in pagina
        /// </summary>
        /// <returns>Een view voor user log-in</returns>
        public ActionResult Inloggen() 
        {
            try
            {
                GebruikerVM gebrVM = new GebruikerVM();
                gebrVM.Retry = false;
                return View(gebrVM);
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
        /// Controleert gebrnaam en ww, indien correct sla op in de sessie
        /// </summary>
        /// <param name="gebruiker">Gebruikersnaam en ww die de gebr heeft ingetikt</param>
        /// <returns>Indien onbekend, terug naar dezelfde pagina, bekend = redirect naar de homepage </returns>
        [HttpPost]
        public IActionResult Inloggen(GebruikerVM gebruiker)
        {               
            try
            {
                if(ModelState.IsValid)
                {
                    Gebruiker gebr = gebrContainer.ZoekGebrOpGebrnaamEnWW(gebruiker.Gerbuikersnaam, gebruiker.Wachtwoord);
                    if (gebr != null)
                    {
                        HttpContext.Session.SetInt32("ID", gebr.ID);
                        return RedirectToAction("Index", "Home", gebruiker);
                    }
                    else
                    {
                        GebruikerVM gebrVM = new GebruikerVM();
                        ModelState.AddModelError("", "Gebruikersnaam en/of wachtwoord is incorrect");
                        return View(gebrVM);
                    }
                }
                return View(gebruiker);
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
        /// Logt een gebruiker uit door sessie uit te zetten
        /// </summary>
        /// <returns>Indien bekende ID een pagina tonen "Uitgelogd", onbekend = pagina tonen "Geen gebr gevonden" </returns>
        [HttpGet]
        public IActionResult Uitloggen()  
        {
            try
            {
                int? ID = HttpContext.Session.GetInt32("ID");
                if (ID != null)
                {
                    HttpContext.Session.Clear();
                    TempData["AllertMessage"] = "U bent succesvol uitgelogd!";
                    return RedirectToAction("Inloggen");
                }
                return RedirectToAction("Index", "Home");
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
        /// Geeft de view voor account registratie
        /// </summary>
        /// <returns>Return pagina waar gebruiker gegevens kan invoeren</returns>
        [HttpGet]
        public ActionResult AccountAanmaken()  
        {
            try
            {
                GebruikerVM gebrVM = new GebruikerVM();
                gebrVM.Retry = false;
                return View(gebrVM);
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
        /// Controleert gebrnaam en alias, indien beide nog niet bekend maak account aan
        /// </summary>
        /// <param name="gebruiker">Gebruikersnaam, alias en ww die de gebr heeft ingetikt</param>
        /// <returns>Indien onbekend maak account aan, bekend = blijf op zelfde pagina en probeer opniew </returns>
        [HttpPost]
        public IActionResult AccountAanmaken(GebruikerVM gebruiker)
        {
            Gebruiker gebr = null;
            try
            {
                if (ModelState.IsValid)
                {
                    gebr = gebrContainer.ZoekGebrOpGebrnaamOfAlias(gebruiker.Gerbuikersnaam, gebruiker.Alias);
                    if (gebr != null)
                    {
                        GebruikerVM gebrVM = new GebruikerVM();
                        ModelState.AddModelError("", "Deze gebruikersnaam en/of alias bestaat al");
                        return View(gebrVM);
                    }
                    else
                    {
                        gebrContainer.CreateGebr(new Gebruiker(gebruiker.ID, gebruiker.Gerbuikersnaam, gebruiker.Alias), gebruiker.Wachtwoord);
                        return RedirectToAction("Index", "Home", gebruiker);
                    }
                }
                return View(gebruiker);
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
    }
}
