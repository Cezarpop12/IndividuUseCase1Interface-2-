using BusnLogicLaag;
using DALMSSQLSERVER;
using Microsoft.AspNetCore.Mvc;
using OutfitKing.Models;

namespace OutfitKing.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IWebHostEnvironment Environment;
        public ReviewContainer reviewContainer = new ReviewContainer(new ReviewMSSQLDAL());
        public OutfitContainer outfitContainer = new OutfitContainer(new OutfitMSSQLDAL());

        public ReviewController(ILogger<ReviewController> logger, IWebHostEnvironment webhostEnvironment)
        {
            _logger = logger;
            Environment = webhostEnvironment;
        }

        /// <summary>
        /// Geeft de pagina om een review te maken voor een outfit
        /// </summary>
        /// <param name="id">De ID van de meegegeven outfit</param>
        /// <returns>Indien gebruiker is ingelogd een pagina waar hij bij een outfit een review kan plaatsen,
        /// indien niet ingelogd pagina "U bent niet ingelogd"</returns>
        [HttpGet]
        public ActionResult ReviewAanmakenOutfit(int id)
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
                    OutfitVM outfit = new(outfitContainer.GetOutfit(id));
                    return View(outfit);
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
        /// De gebruiker kan een review schrijven voor een bepaalde outfit
        /// </summary>
        /// <param name="outfit">De outfit die word meegegeven</param>
        /// <returns>Leidt de gebruiker terug naar de homepagina</returns>
        [HttpPost]
        public IActionResult ReviewAanmakenOutfit(OutfitVM outfit)
        {
            try
            {
                int? ID = HttpContext.Session.GetInt32("ID");
                reviewContainer.VoegReviewToeOutfit(ID.Value, outfit.ID, new Review(outfit.review.ID, outfit.review.OutfitID, outfit.review.Titel, outfit.review.StukTekst, DateTime.Now)); //Hier geef je nogsteeds outfitID mee zodat die hem in de tabel zet onder kopje "outfitID", ook al krijg je id hierboven 
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
        /// Geef een pagina met alle reviews van een gebruiker
        /// </summary>
        /// <returns>Return een view waar de gebruiker zijn reviews kan zien indien gebruiker ingelogd,
        /// anders geef pagina "U bent niet ingelogd"</returns>
        public IActionResult ToonAllReviewsVanGebr()
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
                    List<ReviewVM> Reviews = reviewContainer.GetAllReviewsVanGebr(ID.Value).Select(x => new ReviewVM(x)).ToList();
                    return View(Reviews);
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
        /// Geeft een pagina waar alle reviews kunnen worden gezien van een outfit
        /// </summary>
        /// <param name="id">De outfitId die wordt meegegeven</param>
        /// <returns>Een view waar de reviews zichtbaar zijn van een outfit</returns>
        [HttpGet]
        public ActionResult ToonAlleReviewsOutfit(int id)
        {
            try
            {
                OutfitVM outfit = new(outfitContainer.GetOutfit(id));
                outfit.reviews = reviewContainer.GetAllReviewsVanOutfit(outfit.ID).Select(x => new ReviewVM(x)).ToList();
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
        /// Vult de pagina met een lijst van reviews
        /// </summary>
        /// <param name="outfit">De outfit die is meegegeven</param>
        /// <returns>Return de view met alle reviews vd outfit</returns>
        [HttpPost]
        public IActionResult ToonAlleReviewsOutfit(OutfitVM outfit)
        {
            try
            {
                outfit.reviews = reviewContainer.GetAllReviewsVanOutfit(outfit.ID).Select(x => new ReviewVM(x)).ToList();
                return View("ToonAlleReviewsOutfit", outfit);
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
        /// Verwijder een review
        /// </summary>
        /// <param name="id">De ReviewID die wordt meegegeven</param>
        /// <returns>Leidt de gebruiker naar de pagina met zijn geplaatste reviews</returns>
        public IActionResult ReviewVerwijderen(int id)
        {
            try
            {
                Review review = reviewContainer.GetReview(id);
                reviewContainer.DeleteReview(review);
                return RedirectToAction("ToonAllReviewsVanGebr", "Review");
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
        /// Toont een pagina waar een geplaatste review kan worden aangepast
        /// </summary>
        /// <param name="id">De reviewID die wordt meegegeven</param>
        /// <returns>Een view waar een bepaalde review kan worden aangepast</returns>
        [HttpGet]
        public ActionResult ReviewUpdaten(int id)
        {
            try
            {
                ReviewVM review = new(reviewContainer.GetReview(id));
                return View(review);
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
        /// De gebruiker kan andere waardes invoeren bij zijn eerder geplaatste reviews
        /// </summary>
        /// <param name="review">De review die wordt meegegeven</param>
        /// <returns>Leidt de gebruiker terug naar de homepagina</returns>
        [HttpPost]
        public IActionResult ReviewUpdaten(ReviewVM review)
        {
            try
            {
                reviewContainer.UpdateReview(new Review(review.ID, review.OutfitID, review.Titel, review.StukTekst, DateTime.Now));
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
    }
}
