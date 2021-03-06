using BusnLogicLaag;
using DALMSSQLSERVER;
using Microsoft.AspNetCore.Mvc;
using OutfitKing.Models;

namespace OutfitKing.Controllers
{
    public class OnderdeelController : Controller
    {
        private readonly ILogger<OnderdeelController> _logger;
        private readonly IWebHostEnvironment Environment;
        public OnderdeelContainer onderdeelContainer = new OnderdeelContainer(new OnderdeelMSSQLDAL());

        public OnderdeelController(ILogger<OnderdeelController> logger, IWebHostEnvironment webhostEnvironment)
        {
            _logger = logger;
            Environment = webhostEnvironment;
        }

        /// <summary>
        /// Geeft een pagina met onderdelen van een bepaalde gebruiker
        /// </summary>
        /// <returns>Indien bekende gebruiker return pagina met zijn onderdelen, onbekend = blijf op dezelfde pagina </returns>
        public IActionResult OnderdelenTonenGebr()
        {
            try
            {
                int? ID = HttpContext.Session.GetInt32("ID");
                if (ID != null)
                {
                    List<Onderdeel> Onderdelen = onderdeelContainer.GetAllOnderdelenVanGebr(ID.Value);
                    return View(Onderdelen);
                }
                TempData["AllertMessage"] = "Log eerst in!";
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
        /// Pagina tonen met alle onderdelen die ooit geplaatst zijn
        /// </summary>
        /// <returns>Return een view met een lijst van onderdelen </returns>
        public IActionResult AlleOnderdelenTonen()
        {
            try
            {
                List<Onderdeel> Onderdelen = onderdeelContainer.GetAllOnderdelen();
                return View(Onderdelen);
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
        /// Geeft een onderdeel aanmaak pagina
        /// </summary>
        /// <returns>De view waar een onderdeel kan worden aangemaakt in het geval ingelogd, anders geef pagina "Niet ingelogd"</returns>
        public IActionResult OnderdeelAanmaken()
        {
            try
            {
                int? ID = HttpContext.Session.GetInt32("ID");
                if (ID == null)
                {
                    TempData["AllertMessage"] = "Log eerst in!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
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
        /// Controleert of er een gebruiker is ingelogd 
        /// </summary>
        /// <param name="onderdeel">Onderdeel die wordt meegegeven</param>
        /// <returns> Gebruiker kan waardes invoeren en wordt geleid naar zijn onderdelen </returns>
        [HttpPost]
        public IActionResult OnderdeelAanmaken(OnderdeelVM onderdeel)
        {
            try
            {
                int? ID = HttpContext.Session.GetInt32("ID");
                string FileNaam = UploadFile(onderdeel);
                onderdeelContainer.VoegOnderdeelToe(ID.Value, new Onderdeel(onderdeel.ID, onderdeel.Titel, onderdeel.Prijs, (Onderdeel.OnderdeelCategory)onderdeel.Category, FileNaam));
                return RedirectToAction("OnderdelenTonenGebr");
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
        /// Veranderd de afbeelding-format in een string zodat deze kan worden opgeslagen in db
        /// </summary>
        /// <param name="onderdeel">De onderdeel die meegegeven wordt</param>
        /// <returns>Een file in de vorm van een string</returns>
        private string UploadFile(OnderdeelVM onderdeel)
        {
            string file = null;
            if (onderdeel.Afbeelding != null)
            {
                string uploadDir = Path.Combine(Environment.WebRootPath, "Images");
                file = Guid.NewGuid().ToString() + "_" + onderdeel.Afbeelding.FileName;
                string filePath = Path.Combine(uploadDir, file);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    onderdeel.Afbeelding.CopyTo(fileStream);
                }
            }
            return file;
        }
    }
}

