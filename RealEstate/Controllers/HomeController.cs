using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Reposistory;
using System.Diagnostics;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        private IPostReposistory _postReposistory;
        private ISellerReposistory _sellerReposistory;        
        private IPropertyReposistory _propertyReposistory;
        private INewsReposistory _newsReposistory;
        private IUserReposistory _userReposistory;

        public HomeController(IPostReposistory postReposistory, 
                              ISellerReposistory sellerReposistory, 
                              IPropertyReposistory propertyReposistory, 
                              INewsReposistory newsReposistory,
                              IUserReposistory userReposistory) //store all connection string and table top retrieve data
        {
            _postReposistory = postReposistory;
            _sellerReposistory = sellerReposistory;
            _propertyReposistory = propertyReposistory;
            _newsReposistory = newsReposistory;
            _userReposistory = userReposistory;
        }        

        //GET HOME
        public IActionResult Index()
        {
            HomeModel model = new HomeModel();

            List<Post> objPostList = _postReposistory.GetTop3();            
            model.MyPost = objPostList;

            List<Property> objPropertyList = _propertyReposistory.GetAll();
            model.MyProp = objPropertyList;

            List<Seller> objSellerList = _sellerReposistory.GetTop3();            
            model.MySeller = objSellerList;            

            List<News> objNewsList = _newsReposistory.GetTop3();
            model.MyNews = objNewsList;

            List<LoginUser> objUserList = _userReposistory.GetAll();
            model.MyUser = objUserList;

            return View(model);
        }

        public IActionResult AllProperties()
        {           
            var objPropertyList = _propertyReposistory.GetAll();

            return View("AllProperties", objPropertyList);
        }

        public IActionResult Agent()
        {
            return View();
        }

        public IActionResult AllAgents()
        {
            var objSellerList = _sellerReposistory.GetAll();

            return View("AllAgents", objSellerList);            
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult AllNews()
        {
            var objNewsList = _newsReposistory.GetAll();

            return View("AllNews", objNewsList);
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