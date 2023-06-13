using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Models.Admin_Models;
using RealEstate.Reposistory;

namespace RealEstate.Controllers
{
    public class AdminController : Controller
    {
        private IPostReposistory _postReposistory;
        private ISellerReposistory _sellerReposistory;
        private IPropertyReposistory _propertyReposistory;
        private INewsReposistory _newsReposistory;
        private IUserReposistory _userReposistory;

        public AdminController(IPostReposistory postReposistory,
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Property()
        {
            AdminModel model = new AdminModel();

            List<Post> objPostList = _postReposistory.GetAll();
            model.MyPost = objPostList;

            List<Property> objPropertyList = _propertyReposistory.GetAll();
            model.MyProp = objPropertyList;

            return View(model);
        }
        public IActionResult EditProperty(int Id)
        {
            return View("EditProperty");
        }
        public IActionResult PropertyDetail(int Id)
        {
            Property propertydetail = _propertyReposistory.GetPropertyById(Id);

            return View("PropertyDetail", propertydetail);
        }
        public IActionResult Agent()
        {
            var objSellerList = _sellerReposistory.GetAll();

            return View("Agent", objSellerList);
        }
        public IActionResult AgentDetail(int id)
        {
            Seller sellerDetail = _sellerReposistory.GetById(id);
            return View("AgentDetail", sellerDetail);
        }
        public IActionResult EditAgent(int id)
        {
            Seller sellerEdit = _sellerReposistory.GetById(id);
            return View("EditAgent", sellerEdit);
        }

        /* --------------- NEWS --------------- */
        public IActionResult New()
        {
            var objNewList = _newsReposistory.GetAll();
            return View("New", objNewList);
        }
        public IActionResult AddNew2()
        {
            return View("AddNew2");
        }
        [HttpPost]
        public IActionResult AddNew2(News news)
        {
            _newsReposistory.Addnew(news);
            return RedirectToAction("New");
        }
        public IActionResult NewDetail(int Id)
        {
            var objNew = _newsReposistory.GetById(Id);

            return View("NewDetail", objNew);
        }
        public IActionResult EditingNew(int id)
        {
            var objNew = _newsReposistory.GetById(id);
            return View("EditingNew", objNew);
        }

        [HttpPost]
        public IActionResult EditingNew(News news)
        {
            _newsReposistory.EditingNew(news);
            return RedirectToAction("New");
        }

        public IActionResult DeleteNews(int id)
        {
            var objNew = _newsReposistory.GetById(id);
            return View("DeleteNews", objNew);
        }

        [HttpPost]
        public IActionResult DeleteNews(News news)
        {
            _newsReposistory.DeleteNews(news);

            return RedirectToAction("New");
        }
        /* --------------- PAGES --------------- */
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult ForgetPass()
        {
            return View();
        }
    }
}
