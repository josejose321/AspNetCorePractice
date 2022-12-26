using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using practiceAuthentication.Models;
using System.Diagnostics;

namespace practiceAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int[] output = { 100, 50, 90, 56, 70 };
            ViewBag.output = output;


            return View();
        }
        public IActionResult Profile()
        {
            Profile profile = new Profile()
            {
                Fullname = "Jose Evasco II",
                Email = "Jose.evasco@gatewayvisasolution.com",
                Phone = "09486330988",
                Address = "San Isidro Libamanan Camarines Sur",
                Job = "IT SPECIALIST",
                Country = "PHILIPPINES",
                Company = "EL ROI QNEK VISA CONSULTANCY"
            };
            ViewBag.profile = profile;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}