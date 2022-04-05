using Restaurantmanagment.CustomRoleProvider;
using Restaurantmanagment.Infrastructure.DataProvider;
using Restaurantmanagment.Models.Entity;
using Restaurantmanagment.Models.Entity.Aboutpage;
using Restaurantmanagment.Models.Entity.Gallery;
using Restaurantmanagment.Models.Entity.Gujaratidish;
using Restaurantmanagment.Models.Entity.Homepage;
using Restaurantmanagment.Models.Entity.Panjabidish;
using Restaurantmanagment.Models.Entity.Registerpage;
using Restaurantmanagment.Models.Viewmodel;
using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IServiceProvider = Restaurantmanagment.Infrastructure.DataProvider.IServiceProvider;

namespace Restaurantmanagment.Controllers
{
    
    public class AdminController : Controller    
    {
        private IAdminProvider _dataprovider;

        //************************************************** User Register ******************************************************

        //List User Register
        [CustomAuthentication]
        public ActionResult UserRegList() //List
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                _dataprovider = new AdminProvider();
                UserRegViewmodel Model = _dataprovider.UserList();
                return View(Model);
            }           
        }

        [AllowAnonymous]
        // Create User Register
        public ActionResult UserRegCreate() 
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult UserRegCreate(UserRegViewmodel model)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.UserCreate(model);
            Session["name"] = model.User_Regobj.name.ToString();
            return RedirectToAction("Login", "Home");

        }

        // Update User Register
        public ActionResult UserRegUpdate(Guid id)
        {
            _dataprovider = new AdminProvider();
            UserRegister Model = _dataprovider.UserUpdateId(id);
            return View(Model);
        }

        [HttpPost]
        public ActionResult UserRegUpdate(UserRegister model)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.UserUpdate(model);
            return RedirectToAction("UserRegList", "Admin");

        }

        //Delete
        public ActionResult UserRegDelete(Guid id)  
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.UserDelete(id);
            return RedirectToAction("UserRegList", "Admin");
        }

        //============================================================= About US Page ======================================================

        //List
        public ActionResult AboutList() //List
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                _dataprovider = new AdminProvider();
                UserRegViewmodel Model = _dataprovider.AboutusList();
                return View(Model);
            }           
        }

        // Create 
        public ActionResult AboutCreate()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AboutCreate(UserRegViewmodel model)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.AboutusCreate(model);
            return RedirectToAction("AboutList", "Admin");
        }

        // Update 
        public ActionResult AboutUpdate(Guid id)
        {
            _dataprovider = new AdminProvider();
            Aboutus Model = _dataprovider.AboutusUpdateId(id);
            return View(Model);
        }

        [HttpPost]
        public ActionResult AboutUpdate(Aboutus model)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.AboutusUpdate(model);
            return RedirectToAction("AboutList", "Admin");
        }

        //Delete
        public ActionResult AboutDelete(Guid id)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.AboutusDelete(id);
            return RedirectToAction("AboutList", "Admin");
        }

        //================================================= Gujaratidish Page ===================================
        public ActionResult GujList() //List
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                _dataprovider = new AdminProvider();
                UserRegViewmodel Model = _dataprovider.Getgujlist();
                return View(Model);
            }            
        }

        public ActionResult GujCreate() // Create
        {
            return View();
        }

        [HttpPost]
        public ActionResult GujCreate(UserRegViewmodel model)
        {
            _dataprovider = new AdminProvider();
            string str =  _dataprovider.CreateGujProvider(model);
            return RedirectToAction("GujList", "Admin");           
        }

        public ActionResult GujUpdate(int id) // Update
        {
            _dataprovider = new AdminProvider();
            Gujdish Model = _dataprovider.UpdIdGujProvider(id);
            return View(Model);
        }

        [HttpPost]
        public ActionResult GujUpdate(Gujdish model)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.UpdGujProvider(model);
            return RedirectToAction("GujList", "Admin");
        }
           
        public ActionResult GujDelete(int id)  //Delete
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.DeleteGujProvider(id);
            return RedirectToAction("GujList", "Admin");
        }

        // GET: Admin
        //======================================================= Panjabi Page ============================================
        //List
        public ActionResult PanList() 
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                _dataprovider = new AdminProvider();
                UserRegViewmodel Model = _dataprovider.PanjabiList();
                return View(Model);
            }           
        }

        //Create
        public ActionResult PanCreate() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult PanCreate(UserRegViewmodel model) // Create
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.PanjabiCreate(model);
            return RedirectToAction("PanList", "Admin");           
        }

        // Update
        public ActionResult PanUpdate(int id) // Update
        {
            _dataprovider = new AdminProvider();
            Panjabidish Model = _dataprovider.PanjabiUpdateId(id);
            return View(Model);
        }

        [HttpPost]
        public ActionResult PanUpdate(Panjabidish model)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.PanjabiUpdate(model);
            return RedirectToAction("PanList", "Admin");

        }

        //Delete
        public ActionResult PanDelete(int id)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.PanjabiDelete(id);
            return RedirectToAction("PanList", "Admin");
        }

        //************************************************ Order Item List Page ************************************
        //Order List
        public ActionResult OrderDataList()
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login","Home");
            }
            else
            {
                _dataprovider = new AdminProvider();
                UserRegViewmodel Model = _dataprovider.OrderDataSerList();
                return View(Model);
            }            
        }

        //------------------------ Export Pdf ------------------------- Start -----------------------//
        public ActionResult ExportPdf()
        {
            return new ActionAsPdf("OrderDataList")
            {
                FileName = Server.MapPath("~/assets/Orderdata.pdf")
            };
        }
        //------------------------ Export Pdf ------------------------- End -----------------------//

        //Delete
        public ActionResult OrderDataDelete(int id)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.OrderDataSerDelete(id);
            return RedirectToAction("OrderDataList", "Admin");
        }

        //******************************************************** Gallery page ****************************************

        //List
        public ActionResult GalList()
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                _dataprovider = new AdminProvider();
                UserRegViewmodel Model = _dataprovider.GalleryList();
                return View(Model);
            }           
        }


        //Create
        public ActionResult GalCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GalCreate(UserRegViewmodel model)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.GalleryCreate(model);
            return RedirectToAction("GalList", "Admin");
        }

        // Update
        public ActionResult GalUpdate(Guid id) // Update
        {
            _dataprovider = new AdminProvider();
            Gallery Model = _dataprovider.GalleryUpdateId(id);
            return View(Model);
        }

        [HttpPost]
        public ActionResult GalUpdate(Gallery model)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.GalleryyUpdate(model);
            return RedirectToAction("GalList", "Admin");

        }

        //Delete
        public ActionResult GalDelete(Guid id)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.GalleryDelete(id);
            return RedirectToAction("GalList", "Admin");
        }

        //********************************************************************** Home page ****************************************
        //===================================== Homepage in Banner  ===============================

        //Create Banner
        public ActionResult HBanCreate()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult HBanCreate(UserRegViewmodel model)
        {
            _dataprovider = new AdminProvider();         
            string str = _dataprovider.HBanCreatePro(model);
            return RedirectToAction("HwhyResList","Admin");

        }  


        //------------------ Download --------------- File ----------- Start -------------
        public FileResult DownloadFile(string filename)
        {
            string path = Server.MapPath("~/assets/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }
        //------------------ Download --------------- File ------------ End ------------

        //Delete
        public ActionResult HBanDelete(Guid id)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.HBanDeletePro(id);
            return RedirectToAction("HwhyResList", "Admin");
        }

        //-------------------------------------- Homepage in Why choose our Restauant -------------------------------------//

        // Select - Why choose our Restauant
        public ActionResult HwhyResList()
        {
            if(Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login","Home");
            }
            else
            {
                _dataprovider = new AdminProvider();
                UserRegViewmodel Model = _dataprovider.HSelWhyProvider();
                return View(Model);
            }            
        }

        //Create
        public ActionResult HwhyResCreate()
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }               
        }

        [HttpPost]
        public ActionResult HwhyResCreate(UserRegViewmodel model)
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                _dataprovider = new AdminProvider();
                string str = _dataprovider.HCreateWhyProvider(model);
                return RedirectToAction("HwhyResList", "Admin", model);
            }
        }

        //Update
        public ActionResult HwhyResUpdate(Guid id) 
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                _dataprovider = new AdminProvider();
                H_WhyChooseRes Model = _dataprovider.HUpdateIdWhyProvider(id);
                return View(Model);
            }            
        }

        [HttpPost]        
        public ActionResult HwhyResUpdate(H_WhyChooseRes model)
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                _dataprovider = new AdminProvider();
                string str = _dataprovider.HUpdateWhyProvider(model);
                return RedirectToAction("HwhyResList", "Admin");
            }            
        }

        //Delete
        public ActionResult HwhyResDelete(Guid id)
        {
            if (Session["user"].ToString() != "admin")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                _dataprovider = new AdminProvider();
                string str = _dataprovider.HDeleteWhyProvider(id);
                return RedirectToAction("HwhyResList", "Admin");
            }           
        }

        //===================================================== Homepage in Slider ============================================      

        //Create        
        public ActionResult HsliderCreate()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult HsliderCreate(UserRegViewmodel model)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.HCreateSLider(model);
            return RedirectToAction("HwhyResList", "Admin");

        }

        //Update        
        public ActionResult HsliderUpdate(Guid id)
        {

            _dataprovider = new AdminProvider();
            HomeSlider Model = _dataprovider.HUpdateIdSLider(id);
            return View(Model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult HsliderUpdate(HomeSlider model)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.HUpdateSLider(model);
            return RedirectToAction("HwhyResList", "Admin");
        }

        //Delete
        public ActionResult HsliderDelete(Guid id)
        {
            _dataprovider = new AdminProvider();
            string str = _dataprovider.HDeleteSLider(id);
            return RedirectToAction("HwhyResList", "Admin");
        }


    }
}