using BusnLogicLaag;
using DALMSSQLSERVER;
using Microsoft.AspNetCore.Mvc;

namespace OutfitKing.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IWebHostEnvironment Environment;
        public ReviewContainer reviewContainer = new ReviewContainer(new ReviewMSSQLDAL());

        public ReviewController(ILogger<ReviewController> logger, IWebHostEnvironment webhostEnvironment)
        {
            _logger = logger;
            Environment = webhostEnvironment;
        }
        public IActionResult ToonAllReviewsVanGebr()
        {
            try
            {
                int? ID = HttpContext.Session.GetInt32("ID");
                if (ID != null)
                {
                    List<Review> Reviews = reviewContainer.GetAllReviewsVanGebr(ID.Value);
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
    }
    }
}
