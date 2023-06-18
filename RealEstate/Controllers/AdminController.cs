﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private IAdminReposistory _adminReposistory;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdminController(IPostReposistory postReposistory,
                              ISellerReposistory sellerReposistory,
                              IPropertyReposistory propertyReposistory,
                              INewsReposistory newsReposistory,
                              IUserReposistory userReposistory,
                              IAdminReposistory adminReposistory) //store all connection string and table top retrieve data
        {
            _postReposistory = postReposistory;
            _sellerReposistory = sellerReposistory;
            _propertyReposistory = propertyReposistory;
            _newsReposistory = newsReposistory;
            _userReposistory = userReposistory;
            _adminReposistory = adminReposistory;
        }
        public IActionResult Index()
        {
            string userName = HttpContext.Session.GetString("UserName");
            string email = HttpContext.Session.GetString("Email");
            AdminModel model = new AdminModel();

            List<Post> objPostList = _postReposistory.GetTop3();
            model.MyPost = objPostList;

            List<Property> objPropertyList = _propertyReposistory.GetAll();
            model.MyProp = objPropertyList;

            List<Seller> objSellerList = _sellerReposistory.GetTop3();
            model.MySeller = objSellerList;

            return View(model);
        }

        /* --------------- Property --------------- */

        public IActionResult Property()
        {
            AdminModel model = new AdminModel();

            List<Post> objPostList = _postReposistory.GetAll();
            model.MyPost = objPostList;

            List<Property> objPropertyList = _propertyReposistory.GetAll();
            model.MyProp = objPropertyList;

            return View(model);
        }
        public IActionResult PropertyDetail(int Id)
        {
            var propertydetail = _propertyReposistory.GetPropertyById(Id);

            return View("PropertyDetail", propertydetail);
        }
        public IActionResult EditProperty(int id)
        {
            var objProperty = _propertyReposistory.GetPropertyById(id);
            return View("EditProperty", objProperty);
        }
        [HttpPost]
        public IActionResult EditProperty(Property property)
        {
            _propertyReposistory.EditingProperty(property);
            TempData["Message"] = "Update Property Successfully!!!";
            return RedirectToAction("Property");
        }

        public IActionResult DeleteProperty(int id)
        {
            var delProperty = _propertyReposistory.GetPropertyById(id);

            return View("DeleteProperty", delProperty);
        }

        [HttpPost]
        public IActionResult DeleteProperty(Property property)
        {
            _propertyReposistory.DeleteProperty(property);
            TempData["Message"] = "Delete Property Successfully!!!";

            return RedirectToAction("Property");
        }

        /* --------------- AGENTS --------------- */

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
        public IActionResult EditingAgent(int id)
        {
            Seller sellerEdit = _sellerReposistory.GetById(id);
            return View("EditingAgent", sellerEdit);
        }
        [HttpPost]
        public IActionResult EditingAgent(Seller seller)
        {
            _sellerReposistory.EditingAgent(seller);
            TempData["Message"] = "Update Agent Successfully!!!";

            return RedirectToAction("Agent");
        }
        public IActionResult DeleteAgent(int id)
        {
            var sellerDetail = _sellerReposistory.GetById(id);
            return View("DeleteAgent", sellerDetail);
        }

        [HttpPost]
        public IActionResult DeleteAgent(Seller seller)
        {
            _sellerReposistory.DeleteAgent(seller);
            TempData["Message"] = "Delete Agent Successfully!!!";

            return RedirectToAction("Agent");
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
            string uniqueFileName = UploadImage(news);
            news.Image = uniqueFileName;
            _newsReposistory.UploadFile(news);
            return RedirectToAction(nameof(New));
        }
        public string UploadImage(News news)
        {
            string uniqueFileName = null;

            if (news.ImageUpload != null)
            {
                //đổi đường dẫn mới xài được create
                string uploadFolder = "C://Users//Admin//Desktop//Bài tập về nhà//17,6,2023//RealEstate//RealEstate//wwwroot//img";
                uniqueFileName = Guid.NewGuid().ToString() + "_" + news.ImageUpload.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    news.ImageUpload.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
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
            TempData["Message"] = "Update Successfully!!!";

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

            TempData["Message"] = "Delete Successfully!!!";

            return RedirectToAction("New");
        }
        /* --------------- PAGES --------------- */
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var adlog = _adminReposistory.AdminLogin(admin);
            if (adlog.Count > 0)
            {
                // Successful login
                HttpContext.Session.SetString("UserName", adlog[0].UserName);
                HttpContext.Session.SetString("Email", adlog[0].Email);
                return RedirectToAction("Index");
            }
            else
            {
                // Invalid credentials, show an error message or redirect to the login page
                ModelState.AddModelError("", "Invalid username or password");

                // Clear the input fields by creating a new instance of LoginUser
                var emptyadmin = new Admin();

                // Assign the new instance to the loginUser parameter
                admin.UserName = emptyadmin.UserName;
                admin.PassWord = emptyadmin.PassWord;

                TempData["Message"] = "Incorrect Password or Username. Try Again !!!";
                return View(admin);
            }
        }
        public IActionResult ForgetPass()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear all session data
            return RedirectToAction("Login");
        }
    }
}
