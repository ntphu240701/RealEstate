using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using System.Diagnostics;




namespace RealEstate.Controllers
{


    public class HomeController : Controller
    {
       

        private readonly Ntphu24072001CnaContext _db;

        public HomeController(Ntphu24072001CnaContext db) //store all connection string and table top retrieve data
        {
            _db = db ;
        }
        
        //GET HOME
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

            IEnumerable<Post> objPost = _db.Posts;
            return View(objPost);

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