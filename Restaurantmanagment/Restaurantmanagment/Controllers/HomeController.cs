using Restaurantmanagment.Infrastructure.DataProvider;
using Restaurantmanagment.Models.Entity;
using Restaurantmanagment.Models.Entity.Cart;
using Restaurantmanagment.Models.Entity.Gujaratidish;
using Restaurantmanagment.Models.Entity.Registerpage;
using Restaurantmanagment.Models.Viewmodel;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IServiceProvider = Restaurantmanagment.Infrastructure.DataProvider.IServiceProvider;

namespace Restaurantmanagment.Controllers
{
    public class HomeController : Controller
    {
        private IServiceProvider _serviceProvider;
        private IAdminProvider _dataprovider;


        //************************************************ Book table **************************************
        // Table Book List
        public ActionResult BooktableList()
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                _serviceProvider = new ServiceProvider();
                UserRegViewmodel Model = _serviceProvider.Getbooklist();
                return View(Model);
            }            
        }

        // Table Book create
        public ActionResult Booktable()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Booktable(UserRegViewmodel model)
        {
            _serviceProvider = new ServiceProvider();
            string str = _serviceProvider.CreateServiceProvider(model);
            return RedirectToAction("Gujaratithali", "Home");
        }

        // Table Book Update
        public ActionResult BooktableUpdate(int id)
        {
            _serviceProvider = new ServiceProvider();
            Booktable Model = _serviceProvider.TableUpdIdProvider(id);
            return View(Model);
        }

        [HttpPost]
        public ActionResult BooktableUpdate(Booktable model)
        {
            _serviceProvider = new ServiceProvider();
            string str = _serviceProvider.TableUpdProvider(model);
            return RedirectToAction("BooktableList", "Home");
        }

        // Table Book  Delete        
        public ActionResult Booktbledelete(int id)
        {
            _serviceProvider = new ServiceProvider();
            string str = _serviceProvider.DeletServiceProvider(id);
            return RedirectToAction("BooktableList");
        }

        // Home page
        [ValidateInput(false)]
        public ActionResult Home()
        {
            _dataprovider = new AdminProvider();
            UserRegViewmodel Model = _dataprovider.HSelWhyProvider();
            return View(Model);          
        }

        // About Page
        public ActionResult About()
        {
            _dataprovider = new AdminProvider();
            UserRegViewmodel Model = _dataprovider.AboutusList();
            return View(Model);
        }

        //Gujarati Dish Page
        public ActionResult Gujaratithali()
        {
            _dataprovider = new AdminProvider();     
            UserRegViewmodel Model = _dataprovider.Getgujlist();
            return View(Model);
        }

        // Panjabi Dish Page
        public ActionResult Panjabithali()
        {
            _dataprovider = new AdminProvider();
            UserRegViewmodel Model = _dataprovider.PanjabiList();
            return View(Model);
        }

        //************************************** Add To Cart *****************************************************
        public ActionResult Add(int id)
        {
            _serviceProvider = new ServiceProvider();
            Items Model = _serviceProvider.GetItemById(id);
            if(Session["email"] != null)
            {
                if (Session["cart"] == null)
                {
                    List<Items> li = new List<Items>();
                    li.Add(Model);
                    Session["cart"] = li;
                    ViewBag.cart = li.Count();
                    Session["count"] = 1;
                }
                else
                {
                    List<Items> li = (List<Items>)Session["cart"];
                    li.Add(Model);
                    Session["cart"] = li;
                    ViewBag.cart = li.Count();
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;

                }
                return RedirectToAction("Gujaratithali", "Home");
            }           
           else
            {
                return RedirectToAction("Login", "Home");
            }
        }   

        //************************************** Cart Item Get In Order Page *****************************
        public ActionResult Myorder()
        {
            return View((List<Items>)Session["cart"]);
        }

        public ActionResult ExportPdf()
        {
            return new ActionAsPdf("Myorder")
            {
                FileName = Server.MapPath("~/assets/Orderdata.pdf")
            };
        }
        //************************************** Order Item List Page ************************************

        //Insert
        public ActionResult OrderDataGet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderDataGet(List<Items> item)
        {
            foreach (var items in item)
            {
                _serviceProvider = new ServiceProvider();
                string str = _serviceProvider.OrderDataGetIns(items);
            }
            return RedirectToAction("OrderDataGet","Home");
        }      

        //*************************************************************************************************
        
        // Gallery page
        public ActionResult Gallery()
        {
            _dataprovider = new AdminProvider();
            UserRegViewmodel Model = _dataprovider.GalleryList();
            return View(Model);
        }

        // Contact page
        public ActionResult Contact()
        {
            return View();
        }
        
        //Login In Website
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            _dataprovider = new AdminProvider();
            Login flag = _dataprovider.UserLogin(login);
            if(flag != null)
            {
                Session["email"] = login.email.ToString();
                if(flag.IsAdmin)
                {
                    Session["user"] = "admin";
                    return RedirectToAction("HwhyResList", "Admin");
                }
                else
                {
                    Session["user"] = "user";
                    return RedirectToAction("Gujaratithali", "Home");
                }           
                
            }
            else
            {
                ViewBag.message = "Invalid PassWord";
                return View();
            }
        }

        //Email Verified for Forget Password 
        public ActionResult EmailVerify()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmailVerify(UserRegViewmodel verify)
        {           
            _serviceProvider = new ServiceProvider();
            string str = _serviceProvider.EmailVerifyPass(verify);
            return RedirectToAction("Login");
        }

        //Forget Password
        public ActionResult ForgetPass(Guid id)
        {
            _dataprovider = new AdminProvider();
            UserRegister Model = _dataprovider.UserUpdateId(id);
            return View(Model);
        }

        [HttpPost]
        public ActionResult ForgetPass(UserRegister model)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.UserUpdate(model);
            return RedirectToAction("UserRegList","Admin");
        }


        //Website Logout Page
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }
    }
}
