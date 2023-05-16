using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
