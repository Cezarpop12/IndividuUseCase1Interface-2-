using BusnLogicLaag;
using DALMSSQLSERVER;
using Microsoft.AspNetCore.Mvc;
using OutfitKing.Models;

namespace OutfitKing.Controllers
{
    public class OutfitController : Controller
    {
        private readonly ILogger<OutfitController> _logger;
        private readonly IWebHostEnvironment Environment;
        public OutfitContainer outfitContainer = new OutfitContainer(new OutfitMSSQLDAL());
        public RatingContainer ratingContainer = new RatingContainer(new RatingMSSQLDAL());
        public ReviewContainer reviewContainer = new ReviewContainer(new ReviewMSSQLDAL());

        public OutfitController(ILogger<OutfitController> logger, IWebHostEnvironment webhostEnvironment)
        {
            _logger = logger;
            Environment = webhostEnvironment;
        }

        /// <summary>
        /// Geeft een pagina met Outfits van een bepaalde gebruiker
        /// </summary>
        /// <returns>Indien bekende gebruiker return pagina met zijn outfits, onbekend = blijf op dezelfde pagina </returns>
        public IActionResult OutfitsTonenGebr()
        {
            try
            {
                int? ID = HttpContext.Session.GetInt32("ID");
                if (ID != null)
                {
                    List<Outfit> Outfits = outfitContainer.GetAllOutfitsVanGebr(ID.Value);
                    return View(Outfits);
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
        /// Pagina tonen met alle outfits die ooit geplaatst zijn
        /// </summary>
        /// <returns>Return een view met een lijst van outfits </returns>
        public IActionResult AlleOutfitsTonen()
        {
            try
            {
                List<Outfit> Outfits = outfitContainer.GetAllOutfits();
                return View(Outfits);
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
        /// Geeft een outfit aanmaak pagina
        /// </summary>
        /// <returns>De view waar een outfit kan worden aangemaakt als ingelogd, anders geef pagina "Niet ingelogd"</returns>
        public IActionResult OutfitAanmaken()
        {
            try
            {
                int? ID = HttpContext.Session.GetInt32("ID");
                if (ID == null)
                {
                    return Content("U bent niet ingelogd");
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
        /// <param name="outfit">outfit die wordt meegegeven</param>
        /// <returns>Gebruiker kan zijn outfit aanmaken en wordt doorgeleid naar een pagina met zijn outfits</returns>
        [HttpPost]
        public IActionResult OutfitAanmaken(OutfitVM outfit)
        {
            try
            {
                int? ID = HttpContext.Session.GetInt32("ID");
                string FileNaam = UploadFile(outfit);
                outfitContainer.VoegOutfitToe(ID.Value, new Outfit(outfit.ID, outfit.Titel, outfit.Prijs, (Outfit.OutfitCategory)outfit.Category, FileNaam));
                return RedirectToAction("OutfitsTonenGebr");
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
        /// Verwijderd een outfit
        /// </summary>
        /// <param name="id">OutfitID die wordt meegegeven</param>
        /// <returns>Leidt de gebruiker naar een pagina met zijn outfits </returns>
        public IActionResult OutfitVerwijderen(int id)
        {
            try
            {
                Outfit outfit = outfitContainer.GetOutfit(id);
                outfitContainer.DeleteOutfit(outfit);
                return RedirectToAction("OutfitsTonenGebr", "Outfit");
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
        /// Geeft de pagina om een rating in te voeren
        /// </summary>
        /// <param name="id">De ID van de outfit</param>
        /// <returns>Return een view om ratings in te voeren van een bepaalde outfit</returns>
        [HttpGet]
        public ActionResult OutfitRatingAanmaken(int id)
        {
            try
            {
                OutfitVM outfit = new(outfitContainer.GetOutfit(id));
                outfit.gemRating = ratingContainer.GemRatingBijOutfit(outfit.ID);
                return View(outfit);
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
        /// Gebruiker kan een waarde invoeren
        /// </summary>
        /// <param name="outfit">De outfit die is meegegeven</param>
        /// <param name="GemRating">De gemiddelde rating die wordt opgehaald uit db</param>
        /// <returns>Return de user naar de homepagina</returns>
        [HttpPost]
        public IActionResult OutfitRatingAanmaken(OutfitVM outfit)
        {
            try
            {
                ratingContainer.AddRating(outfit.ID, outfit.rating.Waarde);
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
        /// Geeft een pagina waar een gebruiker zijn geplaatste outfit kan updaten
        /// </summary>
        /// <param name="id">De outfitID die wordt meegegeven</param>
        /// <returns>Return de view waar de outfit kan worden geupdatet</returns>
        [HttpGet]
        public ActionResult OutfitUpdaten(int id)
        {
            try
            {
                OutfitVM outfit = new(outfitContainer.GetOutfit(id));
                return View(outfit);
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
        /// De gebruiker kan andere waardes invoeren dus updaten van een outfit
        /// </summary>
        /// <param name="outfit">De outfit die is meegegeven</param>
        /// <returns>Leidt de gebruiker terug naar de homepagina</returns>
        [HttpPost]
        public IActionResult OutfitUpdaten(OutfitVM outfit)
        {
            try
            {
                string FileNaam = UploadFile(outfit);
                outfitContainer.UpdateOutfit(new Outfit(outfit.ID, outfit.Titel, outfit.Prijs, (Outfit.OutfitCategory)outfit.Category, FileNaam));
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
        /// Veranderd de afbeelding-format in een string zodat deze kan worden opgeslagen in db
        /// </summary>
        /// <param name="outfit">De outfit die meegegeven wordt</param>
        /// <returns>Een file in de vorm van een string</returns>
        private string UploadFile(OutfitVM outfit)
        {
            string file = null;
            if(outfit.Afbeelding != null)
            {
                string uploadDir = Path.Combine(Environment.WebRootPath, "Images");
                file = Guid.NewGuid().ToString() + "_" + outfit.Afbeelding.FileName;
                string filePath = Path.Combine(uploadDir, file);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    outfit.Afbeelding.CopyTo(fileStream);
                }
            }
            return file;
        }
    }
}
