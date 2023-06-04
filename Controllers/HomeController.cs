using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
        private ICategoryReposistory _categoryReposistory;
        private ILocationReposistory _locationReposistory;  

        public HomeController(IPostReposistory postReposistory, 
                              ISellerReposistory sellerReposistory, 
                              IPropertyReposistory propertyReposistory, 
                              INewsReposistory newsReposistory,
                              IUserReposistory userReposistory,
                              ICategoryReposistory categoryReposistory,
                              ILocationReposistory locationReposistory
            ) 
            //store all connection string and table top retrieve data
        {
            _postReposistory = postReposistory;
            _sellerReposistory = sellerReposistory;
            _propertyReposistory = propertyReposistory;
            _newsReposistory = newsReposistory;
            _userReposistory = userReposistory;
            _categoryReposistory = categoryReposistory;
            _locationReposistory = locationReposistory; 
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

        public IActionResult GetPosts()
        {
            List<Post> posts = _categoryReposistory.GetPosts();
            return View("Buy", posts);
        }

        public IActionResult AllProperties()
        {
            var objPropertyList = _postReposistory.GetAll();

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
            var categories = _categoryReposistory.GetProp();

            var location= _locationReposistory.GetPropWLoctation();

            var viewModel = new MyViewModel
            {
                Categories = categories,  
                 Locations = location

            };
            
            return View("Project", viewModel);
        }

        public IActionResult ProjectDetail(int id)
        {
            //var propDetail = _propertyReposistory.GetById(id);

            //return View("ProjectDetail", propDetail);
            //var categories = _categoryReposistory.GetProp();
            var post = _propertyReposistory.GetById(id);


            //var viewModel = new MyViewModel
            //{
            //   Categories = categories,

            //};

            return View("ProjectDetail", post);

        }

        public IActionResult Buy() 
        {
            var categories = _categoryReposistory.GetProp();

            var location = _locationReposistory.GetPropWLoctation();

            var viewModel = new MyViewModel
            {
                Categories = categories,
                Locations = location

            };
            return View("Buy", viewModel);
        }

        public IActionResult BuyDetail()
        {
            return View();
        }

        public IActionResult Rent() 
        {
            var categories = _categoryReposistory.GetProp();

            var location = _locationReposistory.GetPropWLoctation();

            var viewModel = new MyViewModel
            {
                Categories = categories,
                Locations = location

            };
            return View("Rent", viewModel);
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