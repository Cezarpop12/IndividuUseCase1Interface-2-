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
        /// Geef een pagina met alle reviews van een gebruiker
        /// </summary>
        /// <returns>Return een view waar de gebruiker zijn reviews kan zien indien gebruiker ingelogd,
        /// anders geef pagina "U bent niet ingelogd"</returns>
        public IActionResult ToonAllReviewsVanGebr()
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
                    List<Review> Reviews = reviewContainer.GetAllReviewsVanGebr(ID.Value);
                    return View(Reviews);
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

        /// <summary>
        /// Geeft een pagina waar alle review kunnen worden gezien van een outfit
        /// </summary>
        /// <param name="id">De outfitId die wordt meegegeven</param>
        /// <returns>Een view waar de reviews zichtbaar zijn van een outfit</returns>
        [HttpGet]
        public ActionResult ToonAlleReviewsOutfit(int id)
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

        /// <summary>
        /// Vult de pagina met een lijst van outfits
        /// </summary>
        /// <param name="outfit">De outfit die is meegegeven</param>
        /// <returns>    </returns>
        //[HttpPost]
        //public IActionResult ToonAlleReviewsOutfit(OutfitVM outfit)
        //{
        //    List<ReviewVM> reviews = reviewContainer.GetAllReviewsVanOutfit(outfit.ID).Select(x => new ReviewVM(x)).ToList();
        //}

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
                return Content($"Er heeft een fout plaatsgevonden, probeer het in 5 minuten nog eens. " + ex.Message);
            }
            catch (PermanentExceptions ex)
            {
                return Redirect("https://twitter.com/outfitservicestatus");
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
                return Content($"Er heeft een fout plaatsgevonden, probeer het in 5 minuten nog eens. " + ex.Message);
            }
            catch (PermanentExceptions ex)
            {
                return Redirect("https://twitter.com/outfitservicestatus");
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
            reviewContainer.UpdateReview(new Review(review.ID, review.OutfitID, review.Titel, review.StukTekst, DateTime.Now));
            return RedirectToAction("Index", "Home");
        }
    }
}
