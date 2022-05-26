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

        public IActionResult OnderdelenTonenGebr()
        {
            try
            {
                int? ID = HttpContext.Session.GetInt32("ID");
                List<Onderdeel> Onderdelen = onderdeelContainer.GetAllOnderdelenVanGebr(ID.Value);
                return View(Onderdelen);
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

        public IActionResult AlleOnderdelenTonen()
        {
            try
            {
                List<Onderdeel> Onderdelen = onderdeelContainer.GetAllOnderdelen();
                return View(Onderdelen);
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

        public IActionResult OnderdeelAanmaken()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OnderdeelAanmaken(OnderdeelVM onderdeel)
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
                    string FileNaam = UploadFile(onderdeel);
                    onderdeelContainer.VoegOnderdeelToe(ID.Value, new Onderdeel(onderdeel.ID, onderdeel.Titel, onderdeel.Prijs, (Onderdeel.OnderdeelCategory)onderdeel.Category, FileNaam));
                    return RedirectToAction("OnderdelenTonenGebr");
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

