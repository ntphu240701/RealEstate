using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using System.Diagnostics;

namespace RealEstate.Controllers
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
            return View();
        }

        public IActionResult AllProperties()
        {
            return View();
        }

        public IActionResult Agent()
        {
            return View();
        }

        public IActionResult AllAgents()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult AllNews()
        {
            return View();
        }

        public IActionResult Project()
        {
            return View();
        }

        public IActionResult ProjectDetail()
        {
            return View();
        }

        public IActionResult Buy() 
        {
            return View();
        }

        public IActionResult BuyDetail()
        {
            return View();
        }

        public IActionResult Rent() 
        {
            return View();
        }

        public IActionResult RentDetail()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Login() 
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