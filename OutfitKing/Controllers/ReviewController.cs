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

        [HttpPost]
        public IActionResult ToonAlleReviewsOutfit(ReviewVM review)
        {
            \lsd jgna jgjosajodk
            reviewContainer.UpdateReview(new Review(review.ID, review.Titel, review.StukTekst, DateTime.Now));
            return RedirectToAction("Index", "Home");
        }

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

        [HttpPost]
        public IActionResult ReviewUpdaten(ReviewVM review)
        {
            reviewContainer.UpdateReview(new Review(review.ID, review.Titel, review.StukTekst, DateTime.Now));
            return RedirectToAction("Index", "Home");
        }
    }
}
