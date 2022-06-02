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
                return Content($"Er heeft een fout plaatsgevonden, probeer het in 5 minuten nog eens. " + ex.Message);
            }
            catch (PermanentExceptions ex)
            {
                return Redirect("https://twitter.com/outfitservicestatus");
            }
        }

        public IActionResult AlleOutfitsTonen()
        {
            try
            {
                List<Outfit> Outfits = outfitContainer.GetAllOutfits();
                return View(Outfits);
            }
            catch (TemporaryExceptions ex)
            {
                return Content($"Er heeft een fout plaatsgevonden, probeer het in 5 minuten nog eens. " + ex.Message);
            }
            catch (PermanentExceptions ex)
            {
                return Redirect("https://twitter.com/outfitservicestatus");
            }
        }

        public IActionResult OutfitAanmaken()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OutfitAanmaken(OutfitVM outfit)
        {
            int? ID = HttpContext.Session.GetInt32("ID");
            try
            {
                if (ID == null)
                {
                    return Content("U bent niet ingelogd");
                }
                else
                {
                    string FileNaam = UploadFile(outfit);
                    outfitContainer.VoegOutfitToe(ID.Value, new Outfit(outfit.ID, outfit.Titel, outfit.Prijs, (Outfit.OutfitCategory)outfit.Category, FileNaam));
                    return RedirectToAction("OutfitsTonenGebr");
                }
            }
            catch (TemporaryExceptions ex)
            {
                return Content($"Er heeft een fout plaatsgevonden, probeer het in 5 minuten nog eens. " + ex.Message);
            }
            catch (PermanentExceptions ex)
            {
                return Redirect("https://twitter.com/outfitservicestatus");
            }
        }

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
                return Content($"Er heeft een fout plaatsgevonden, probeer het in 5 minuten nog eens. " + ex.Message);
            }
            catch (PermanentExceptions ex)
            {
                return Redirect("https://twitter.com/outfitservicestatus");
            }
        }

        [HttpGet]
        public ActionResult OutfitRatingOpslaan(int id)
        {
            OutfitVM outfit = new(outfitContainer.GetOutfit(id));
            return View(outfit);
        }

        [HttpPost]
        public IActionResult OutfitRatingOpslaan(OutfitVM outfit, int GemRating)
        {
            ratingContainer.AddRating(outfit.ID, outfit.rating.Waarde);
            GemRating = ratingContainer.GemRatingBijOutfit(outfit.ID);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult OutfitReviewOpslaan(int id)
        {
            int? ID = HttpContext.Session.GetInt32("ID");
            try
            {
                if (ID == null)
                {
                    return Content("U bent niet ingelogd");
                }
                else
                {
                    OutfitVM outfit = new(outfitContainer.GetOutfit(id));
                    return View(outfit);
                }
            }
            catch (TemporaryExceptions ex)
            {
                return Content($"Er heeft een fout plaatsgevonden, probeer het in 5 minuten nog eens. " + ex.Message);
            }
            catch (PermanentExceptions ex)
            {
                return Redirect("https://twitter.com/outfitservicestatus");
            }
        }

        [HttpPost]
        public IActionResult OutfitReviewOpslaan(OutfitVM outfit)
        {
            int? ID = HttpContext.Session.GetInt32("ID");
            reviewContainer.VoegReviewToeOutfit(ID.Value, outfit.ID, new Review(outfit.review.ID, outfit.review.OutfitID, outfit.review.Titel, outfit.review.StukTekst, DateTime.Now)); //Hier geef je nogsteeds outfitID mee zodat die hem in de tabel zet onder kopje "outfitID", ook al krijg je id hierboven 
            return RedirectToAction("Index", "Home");
        }

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
                return Content($"Er heeft een fout plaatsgevonden, probeer het in 5 minuten nog eens. " + ex.Message);
            }
            catch (PermanentExceptions ex)
            {
                return Redirect("https://twitter.com/outfitservicestatus");
            }
        }

        [HttpPost]
        public IActionResult OutfitUpdaten(OutfitVM outfit)
        {
            string FileNaam = UploadFile(outfit);
            outfitContainer.UpdateOutfit(new Outfit(outfit.ID, outfit.Titel, outfit.Prijs, (Outfit.OutfitCategory)outfit.Category, FileNaam));
            return RedirectToAction("Index", "Home");
        }

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
