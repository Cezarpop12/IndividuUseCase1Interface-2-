using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutfitKing.Models;
using System.Diagnostics;

namespace OutfitKing.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Controllers zijn classes die luisteren naar de url die je intikt
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// (ILogger<HomeController> logger) = dependency injection. 
        /// Een object hangt af van een ander object. Je geeft het object de objecten mee die hij nodig heeft
        /// https://www.tutorialspoint.com/explain-dependency-injection-in-chash
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Op de actionresults kan gekilt worden op de webpagina, vervolgens krijg je daar de juiste view bij
        //zodra je een view aanmaakt, kan je daar zetten wat je moet ZIEN bij de klik op de webpagina, dus bijv een tekst ofso
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        ///Met [Authorize] kan je er niet zomaar in
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult InlogPagina()
        {
            return View();
        }

        /// <summary>
        /// Je hebt tegen de cookie verteld om /login te pakken , en niet home/login
        /// Ik denk door de cookie dat inlogpagina nu naar login leidt, waarin je bij login view zet wat er moet komen te staan,
        /// na de click op inlogpagina
        /// of misschien zeg je dat login nu een url heeft , ff uitleg
        /// </summary>
        /// <returns></returns>
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Post methode die verwijst naar "login"
        /// </summary>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Validatie(string username, string password)
        {
            if(username == "Sahbi" && password == "Sahbi7")
            {
                return Ok();
            }
            return BadRequest();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}