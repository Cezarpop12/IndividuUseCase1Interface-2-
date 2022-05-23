using BusnLogicLaag;
using DALMSSQLSERVER;
using Microsoft.AspNetCore.Mvc;
using OutfitKing.Models;

namespace OutfitKing.Controllers
{
    public class ToevoegController : Controller
    {
        private readonly ILogger<ToevoegController> _logger;
        private readonly IWebHostEnvironment Environment;
        public OutfitContainer outfitContainer = new OutfitContainer(new OutfitMSSQLDAL());
        

        public ToevoegController(ILogger<ToevoegController> logger, IWebHostEnvironment webhostEnvironment)
        {
            _logger = logger;
            Environment = webhostEnvironment;
        }

        public IActionResult OutfitToevoegen()
        {
   
            var Outfits = outfitContainer.GetAllOutfits().ToList();
            return View(Outfits);
        }

        public IActionResult OutfitAanmaken()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OutfitAanmaken(OutfitVM outfit)
        {
            int? ID = HttpContext.Session.GetInt32("ID");
            if (ID == null)
            {
                return Content("U bent niet ingelogd");
            }
            else
            {
                string FileNaam = UploadFile(outfit);
                outfitContainer.VoegOutfitToe(ID.Value, new Outfit(outfit.Titel, outfit.Prijs, (Outfit.OutfitCategory)outfit.Category, FileNaam));
                return RedirectToAction("OutfitToevoegen");
            }
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
