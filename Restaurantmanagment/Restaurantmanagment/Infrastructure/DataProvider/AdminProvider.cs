using Restaurantmanagment.Models;
using Restaurantmanagment.Models.Entity;
using Restaurantmanagment.Models.Entity.Homepage;
using Restaurantmanagment.Models.Entity.Gujaratidish;
using Restaurantmanagment.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using Restaurantmanagment.Models.Entity.Registerpage;
using System.Web.Security;
using Restaurantmanagment.Models.Entity.Panjabidish;
using Restaurantmanagment.Models.Entity.Aboutpage;
using Restaurantmanagment.Models.Entity.Cart;
using Restaurantmanagment.Models.Entity.Gallery;

namespace Restaurantmanagment.Infrastructure.DataProvider
{
    public class AdminProvider : BaseDataProvider, IAdminProvider
    {
        //Admin Controller 

        //================================================ User Register ==========================================
        //List User
        public UserRegViewmodel UserList()
        {
            UserRegViewmodel list = new UserRegViewmodel();
            DataSet ds = GetDataSet("sp_reg_select", null);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                UserRegViewmodel newlist = new UserRegViewmodel();
                newlist.User_Regobj.uid = Guid.Parse(Convert.ToString(ds.Tables[0].Rows[i]["uid"]));
                newlist.User_Regobj.name = Convert.ToString(ds.Tables[0].Rows[i]["name"]);
                newlist.User_Regobj.email = Convert.ToString(ds.Tables[0].Rows[i]["email"]);
                newlist.User_Regobj.password = Convert.ToString(ds.Tables[0].Rows[i]["password"]);
                newlist.User_Regobj.phone = Convert.ToString(ds.Tables[0].Rows[i]["phone"]);

                list.User_Reglist.Add(newlist.User_Regobj);
            }

            return list;
        }

        //Crete User
        public string UserCreate(UserRegViewmodel vModel)
        {
            try
            {
                var searchList = new List<SearchValueData>
                     {
                         new SearchValueData { Name = "name", Value = vModel.User_Regobj.name },
                         new SearchValueData { Name = "email", Value = vModel.User_Regobj.email },
                         new SearchValueData { Name = "password", Value = vModel.User_Regobj.password },
                         new SearchValueData { Name = "phone", Value = vModel.User_Regobj.phone }                       
                     };

                DataSet userList = GetDataSet("sp_reg_insert", searchList);
                return "Successful Added";
            }
            catch (Exception)
            {
                return "Not Successful Added";
            }
        }

        // User - Login
        public Login UserLogin(Login l1)
        {
          
            var serchList = new List<SearchValueData>();
            var serchvaluedata = new SearchValueData { Name = "email", Value = l1.email.ToString() };           
            var serchvaluedata1 = new SearchValueData { Name = "password", Value = l1.password.ToString() };
            serchList.Add(serchvaluedata);
            serchList.Add(serchvaluedata1);
           

            Login usr_login = GetEntity<Login>("sp_reg_login", serchList);
            FormsAuthentication.SetAuthCookie(l1.email, false);
            return usr_login;
        }

        // Update -id get
        public UserRegister UserUpdateId(Guid id)
        {

            var searchList = new List<SearchValueData>
                {
                    new SearchValueData { Name = "uid", Value = Convert.ToString(id) }

                };
            UserRegister getinfo = GetEntity<UserRegister>("sp_reg_update_id", searchList);
            return getinfo;
        }

        // Update
        public string UserUpdate(UserRegister model)
        {   
            var searchList = new List<SearchValueData>
             {
                 new SearchValueData { Name = "uid", Value = model.uid.ToString()},
                 new SearchValueData { Name = "name", Value = model.name },
                 new SearchValueData { Name = "email", Value = model.email },
                 new SearchValueData { Name = "password", Value = model.password },
                 new SearchValueData { Name = "phone", Value = model.phone }
             };

            DataSet userList = GetDataSet("sp_reg_update", searchList);

            return "Successful Updated";
        }

        public string UserDelete(Guid id)
        {
            var searchList = new List<SearchValueData>
            {
                new SearchValueData {Name = "uid", Value = id.ToString()}
            };
            DataSet userlist = GetDataSet("sp_reg_delete", searchList);
            return "Data Deleted Successfully";
        }

        //=========================================================== About Us dish =============================================================
        
        //Create
        public string AboutusCreate(UserRegViewmodel vModel)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if(file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/img/About/" + filename));
                vModel.About_obj.image = filename;
                file.SaveAs(imgpath);
            }
            try
            {

                var searchList = new List<SearchValueData>
                     {
                         new SearchValueData { Name = "image", Value = vModel.About_obj.image },
                         new SearchValueData { Name = "name", Value = vModel.About_obj.name},
                         new SearchValueData { Name = "role", Value = vModel.About_obj.role },
                         new SearchValueData { Name = "fb", Value = vModel.About_obj.fb},
                         new SearchValueData { Name = "insta", Value = vModel.About_obj.insta }
                     };

                DataSet userList = GetDataSet("sp_about_insert", searchList);               
                return "Data Added Successfully";
            }
            catch (Exception)
            {
                return "Data Not  Added Successfully";
            }
        }

        //List 
        public UserRegViewmodel AboutusList()
        {
            UserRegViewmodel list = new UserRegViewmodel();
            DataSet ds = GetDataSet("sp_about_select", null);
            for(int i=0; i< ds.Tables[0].Rows.Count; i++)
            {
                UserRegViewmodel newlist = new UserRegViewmodel();
                newlist.About_obj.aid = Guid.Parse(Convert.ToString(ds.Tables[0].Rows[i]["aid"]));
                newlist.About_obj.image = Convert.ToString(ds.Tables[0].Rows[i]["image"]);
                newlist.About_obj.name = Convert.ToString(ds.Tables[0].Rows[i]["name"]);
                newlist.About_obj.role = Convert.ToString(ds.Tables[0].Rows[i]["role"]);
                newlist.About_obj.fb = Convert.ToString(ds.Tables[0].Rows[i]["fb"]);
                newlist.About_obj.insta = Convert.ToString(ds.Tables[0].Rows[i]["insta"]);

                list.About_list.Add(newlist.About_obj);
            }    

            return list;
        }

        // Update -id get
        public Aboutus AboutusUpdateId(Guid id)
        {

            var searchList = new List<SearchValueData>
                {
                    new SearchValueData { Name = "aid", Value = Convert.ToString(id) }

                };
            Aboutus getinfo = GetEntity<Aboutus>("sp_about_update_id", searchList);
            return getinfo;
        }

        // Update
        public string AboutusUpdate(Aboutus Model)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if (file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/img/About/" + filename));
                Model.image = filename;
                file.SaveAs(imgpath);
            }

            var searchList = new List<SearchValueData>
             {
                 new SearchValueData { Name = "aid", Value = Model.aid.ToString()},
                 new SearchValueData { Name = "image", Value = Model.image },
                 new SearchValueData { Name = "name", Value = Model.name },
                 new SearchValueData { Name = "role", Value = Model.role},
                 new SearchValueData { Name = "fb", Value = Model.fb },
                 new SearchValueData { Name = "insta", Value = Model.insta }
             };

            DataSet userList = GetDataSet("sp_about_update", searchList);

            return "Successful Updated";
        }

        // Delete 
        public string AboutusDelete(Guid id)
        {
            var searchList = new List<SearchValueData>
            {
                new SearchValueData {Name = "aid", Value = id.ToString() }
            };
            DataSet userlist = GetDataSet("sp_about_delete", searchList);
            return "Record Delete Successful";
        }


        //================================================ Gujarati dish ==========================================
        //GujCreate method
        public string CreateGujProvider(UserRegViewmodel vModel)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if (file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/" + filename));
                vModel.Guj_obj.gimage = filename;
                file.SaveAs(imgpath);
            }
            try
            {
                var searchList = new List<SearchValueData>
                     {
                         new SearchValueData { Name = "gimage", Value = vModel.Guj_obj.gimage },
                         new SearchValueData { Name = "gname", Value = vModel.Guj_obj.gname },
                         new SearchValueData { Name = "gprice", Value = vModel.Guj_obj.gprice.ToString() }

                     };

                DataSet userList = GetDataSet("sp_guj_insert", searchList);
                return "Successful Added";
            }
            catch (Exception)
            {
                return "not Successful";
            }
        }

        //Gujdish List record
        public UserRegViewmodel Getgujlist()
        {
            UserRegViewmodel list = new UserRegViewmodel();
            DataSet ds = GetDataSet("sp_guj_select", null);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                UserRegViewmodel newlist = new UserRegViewmodel();
                newlist.Guj_obj.id = int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["id"]));
                newlist.Guj_obj.gimage = Convert.ToString(ds.Tables[0].Rows[i]["gimage"]);
                newlist.Guj_obj.gname = Convert.ToString(ds.Tables[0].Rows[i]["gname"]);
                newlist.Guj_obj.gprice = Convert.ToString(ds.Tables[0].Rows[i]["gprice"]);

                list.Guj_list.Add(newlist.Guj_obj);
            }

            return list;
        }

        // Update -id get
        public Gujdish UpdIdGujProvider(int id)
        {

            var searchList = new List<SearchValueData>
                {
                    new SearchValueData { Name = "id", Value = Convert.ToString(id) }

                };
            Gujdish getinfo = GetEntity<Gujdish>("sp_guj_upd_id", searchList);
            return getinfo;
        }

        // Update
        public string UpdGujProvider(Gujdish vModel)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if (file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/" + filename));
                vModel.gimage = filename;
                file.SaveAs(imgpath);
            }

            var searchList = new List<SearchValueData>
             {
                 new SearchValueData { Name = "id", Value = vModel.id.ToString()},
                 new SearchValueData { Name = "gimage", Value = vModel.gimage },
                 new SearchValueData { Name = "gname", Value = vModel.gname },
                 new SearchValueData { Name = "gprice", Value = vModel.gprice.ToString() }
             };

            DataSet userList = GetDataSet("sp_guj_update", searchList);

            return "Successful Updated";
        }

        //Gujdish Delete record
        public string DeleteGujProvider(int id)
        {
            var searchList = new List<SearchValueData>
            {
                new SearchValueData {Name = "id", Value = id.ToString() }
            };
            DataSet userlist = GetDataSet("sp_guj_delete", searchList);
            return "Record Delete Successful";
        }

        //*************************************************** Panjabi Dish *********************************************************

        //List
        public UserRegViewmodel PanjabiList()
        {
            UserRegViewmodel list = new UserRegViewmodel();
            DataSet ds = GetDataSet("sp_pan_select", null);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                UserRegViewmodel newlist = new UserRegViewmodel();
                newlist.Pan_obj.pid = int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["pid"]));
                newlist.Pan_obj.image = Convert.ToString(ds.Tables[0].Rows[i]["image"]);
                newlist.Pan_obj.name = Convert.ToString(ds.Tables[0].Rows[i]["name"]);
                newlist.Pan_obj.price = Convert.ToString(ds.Tables[0].Rows[i]["price"]);

                list.Pan_list.Add(newlist.Pan_obj);
            }

            return list;
        }

        //Create
        public string PanjabiCreate(UserRegViewmodel vModel)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if (file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/" + filename));
                vModel.Pan_obj.image = filename;
                file.SaveAs(imgpath);
            }
            try
            {
                var searchList = new List<SearchValueData>
                {                  
                    new SearchValueData {  Name="image", Value = vModel.Pan_obj.image },
                    new SearchValueData {  Name="name", Value = vModel.Pan_obj.name },
                    new SearchValueData {  Name="price", Value = vModel.Pan_obj.price }                   
                };
                DataSet userList = GetDataSet("sp_pan_insert", searchList);
                return "Data Added Successfully";
            }
            catch (Exception)
            {
                return "Data  Not Added Successfully";
            }            
        }

        // Update - id get
        public Panjabidish PanjabiUpdateId(int pid)
        {

            var searchList = new List<SearchValueData>
                {
                    new SearchValueData { Name = "pid", Value = Convert.ToString(pid) }

                };
            Panjabidish getinfo = GetEntity<Panjabidish>("sp_pan_update_id", searchList);
            return getinfo;
        }

        // Update
        public string PanjabiUpdate(Panjabidish Model)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if (file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/" + filename));
                Model.image = filename;
                file.SaveAs(imgpath);
            }

            var searchList = new List<SearchValueData>
             {
                 new SearchValueData { Name = "pid", Value = Model.pid.ToString()},
                 new SearchValueData { Name = "image", Value = Model.image },
                 new SearchValueData { Name = "name", Value = Model.name },
                 new SearchValueData { Name = "price", Value = Model.price }
             };

            DataSet userList = GetDataSet("sp_pan_update", searchList);
            return "Successful Updated";
        }

        //Delete
        public string PanjabiDelete(int pid)
        {
            var searchList = new List<SearchValueData>
            {
                new SearchValueData {Name = "pid", Value = pid.ToString() }
            };
            DataSet userlist = GetDataSet("sp_pan_delete", searchList);
            return "Record Delete Successful";
        }

        //********************************************** Order Data Get List *************************************** 
       
        // ------------ List ----------------
        public UserRegViewmodel OrderDataSerList()
        {
            UserRegViewmodel list = new UserRegViewmodel();
            DataSet ds = GetDataSet("sp_itemlist_select", null);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Items newlist = new Items();
                newlist.id = int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["id"]));
                newlist.uname = Convert.ToString(ds.Tables[0].Rows[i]["uname"]);
                newlist.name = Convert.ToString(ds.Tables[0].Rows[i]["name"]);
                newlist.quantity = int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["quantity"]));
                newlist.price = Convert.ToString(ds.Tables[0].Rows[i]["price"]);
                newlist.amount = Convert.ToString(ds.Tables[0].Rows[i]["amount"]);
                newlist.total = int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["total"]));

                list.Item_list.Add(newlist);
            }
            return list;
        }

        //------------------------ Delete -------------------
        public string OrderDataSerDelete(int id)
        {
            var searchList = new List<SearchValueData>
            {
                new SearchValueData {Name = "id", Value = id.ToString() }
            };
            DataSet userlist = GetDataSet("sp_itemlist_delete", searchList);
            return "Record Delete Successful";
        }

        //********************************************* Gallery services ***********************************************************

        //List
        public UserRegViewmodel GalleryList()
        {
            UserRegViewmodel list = new UserRegViewmodel();
            DataSet ds = GetDataSet("sp_gallery_select", null);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                UserRegViewmodel newlist = new UserRegViewmodel();
                newlist.Gal_obj.gid = Guid.Parse(Convert.ToString(ds.Tables[0].Rows[i]["gid"]));
             
                newlist.Gal_obj.image = Convert.ToString(ds.Tables[0].Rows[i]["image"]);              

                list.Gal_list.Add(newlist.Gal_obj);
            }

            return list;
        }

        //Create
        public string GalleryCreate(UserRegViewmodel vModel)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if (file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/img/g/" + filename));
                vModel.Gal_obj.image = filename;
                file.SaveAs(imgpath);
            }
            try
            {
                var searchList = new List<SearchValueData>
                {
                   
                    new SearchValueData {  Name="image", Value = vModel.Gal_obj.image }                   
                };
                DataSet userList = GetDataSet("sp_gallery_insert", searchList);
                return "Data Added Successfully";
            }
            catch (Exception)
            {
                return "Data  Not Added Successfully";
            }
        }

        // Update - id get
        public Gallery GalleryUpdateId(Guid id)
        {

            var searchList = new List<SearchValueData>
                {
                    new SearchValueData { Name = "gid", Value = Convert.ToString(id) }

                };
            Gallery getinfo = GetEntity<Gallery>("sp_gallery_update_id", searchList);
            return getinfo;
        }

        // Update
        public string GalleryyUpdate(Gallery Model)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if (file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/img/g/" + filename));
                Model.image = filename;
                file.SaveAs(imgpath);
            }

            var searchList = new List<SearchValueData>
             {
                 new SearchValueData { Name = "gid", Value = Model.gid.ToString()},
                
                 new SearchValueData { Name = "image", Value = Model.image }                
             };

            DataSet userList = GetDataSet("sp_gallery_update", searchList);
            return "Successful Updated";
        }

        //Delete
        public string GalleryDelete(Guid id)
        {        
           
            var searchList = new List<SearchValueData>
            {
                new SearchValueData {Name = "gid", Value = id.ToString() }
            };
            DataSet userlist = GetDataSet("sp_gallery_delete", searchList);
            return "Record Delete Successful";

        }


        //********************************************* Homepage services ***********************************************************

        //=================================== Banner in Home page ================================   

        //Create Banner
        public string HBanCreatePro(UserRegViewmodel vModel) 
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if (file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/" + filename));
                vModel.Hbanner_obj.himage = filename;
                file.SaveAs(imgpath);
            }
            try
            {
                var searchList = new List<SearchValueData>
                     {
                       
                        new SearchValueData { Name = "himage", Value = vModel.Hbanner_obj.himage}                         
                     };

                DataSet userList = GetDataSet("sp_Hbanner_insert", searchList);
                return "Successful Added";
            }
            catch (Exception)
            {
                return "Not Successful Added";
            }
        }

        // Delete Banner record
        public string HBanDeletePro(Guid id)
        {
            var searchList = new List<SearchValueData>
            {
                new SearchValueData {Name = "imgid", Value = id.ToString() }
            };
            DataSet userlist = GetDataSet("sp_Hbanner_delete", searchList);
            return "Record Delete Successful";
        }
        //==================================== Why choose Our Restaurant & Home page =================================
        //create 
        public string HCreateWhyProvider(UserRegViewmodel vModel) 
        {
            try
            {
                var searchList = new List<SearchValueData>
                     {
                         new SearchValueData { Name = "wnumber", Value = vModel.HwhyRes_obj.wnumber },
                         new SearchValueData { Name = "wtitle", Value = vModel.HwhyRes_obj.wtitle },
                         new SearchValueData { Name = "wdescription", Value = vModel.HwhyRes_obj.wdescription }
                     };

                DataSet userList = GetDataSet("sp_Hwhy_insert", searchList);
                return "Successful Added";
            }
            catch (Exception)
            {
                return "Not Successful Added";
            }
        }

        //Select - list
        public UserRegViewmodel HSelWhyProvider() 
        {
            UserRegViewmodel list = new UserRegViewmodel();
            DataSet ds = GetDataSet("sp_Hwhy_select", null);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                UserRegViewmodel newlist = new UserRegViewmodel();
                newlist.HwhyRes_obj.wid = Guid.Parse(Convert.ToString(ds.Tables[0].Rows[i]["wid"]));
                newlist.HwhyRes_obj.wnumber = Convert.ToString(ds.Tables[0].Rows[i]["wnumber"]);
                newlist.HwhyRes_obj.wtitle = Convert.ToString(ds.Tables[0].Rows[i]["wtitle"]);
                newlist.HwhyRes_obj.wdescription = Convert.ToString(ds.Tables[0].Rows[i]["wdescription"]);               

                list.HwhyRes_list.Add(newlist.HwhyRes_obj);
            }

            for (int i = 0; i < ds.Tables[1].Rows.Count; i++) // List Banner
            {
                UserRegViewmodel newlist = new UserRegViewmodel();
                newlist.Hbanner_obj.imgid = Guid.Parse(Convert.ToString(ds.Tables[1].Rows[i]["imgid"]));
                newlist.Hbanner_obj.himage = Convert.ToString(ds.Tables[1].Rows[i]["himage"]);                

                list.Hbanner_list.Add(newlist.Hbanner_obj);
            }

            for (int i = 0; i < ds.Tables[2].Rows.Count; i++) // List Slider
            {
                UserRegViewmodel newlist = new UserRegViewmodel();
                newlist.Hslider_obj.sid = Guid.Parse(Convert.ToString(ds.Tables[2].Rows[i]["sid"]));
                newlist.Hslider_obj.image = Convert.ToString(ds.Tables[2].Rows[i]["image"]);
                newlist.Hslider_obj.title = Convert.ToString(ds.Tables[2].Rows[i]["title"]);
                newlist.Hslider_obj.price = Convert.ToString(ds.Tables[2].Rows[i]["price"]);
                newlist.Hslider_obj.description = Convert.ToString(ds.Tables[2].Rows[i]["description"]);


                list.Hslider_list.Add(newlist.Hslider_obj);
            }

            return list;
        }

        // Update -id get
        public H_WhyChooseRes HUpdateIdWhyProvider(Guid id)
        {

            var searchList = new List<SearchValueData>
                {
                    new SearchValueData { Name = "wid", Value = Convert.ToString(id) }

                };
            H_WhyChooseRes getinfo = GetEntity<H_WhyChooseRes>("sp_Hwhy_upd_id", searchList);
            return getinfo;
        }

        // Update
        public string HUpdateWhyProvider(H_WhyChooseRes vModel)
        {
            
            var searchList = new List<SearchValueData>
             {
                 new SearchValueData { Name = "wid", Value = vModel.wid.ToString()},
                 new SearchValueData { Name = "wnumber", Value = vModel.wnumber},
                 new SearchValueData { Name = "wtitle", Value = vModel.wtitle},
                 new SearchValueData { Name = "wdescription", Value = vModel.wdescription}
             };

            DataSet userList = GetDataSet("sp_Hwhy_update", searchList);

            return "Successful Added";
        }

        // Delete
        public string HDeleteWhyProvider(Guid id)// Delete
        {
            var searchList = new List<SearchValueData>
            {
                new SearchValueData {Name = "wid", Value = id.ToString() }
            };
            DataSet userlist = GetDataSet("sp_Hwhy_delete", searchList);
            return "Record Delete Successful";
        }

        //====================================================== Slider in Home page =================================================   
        //Create Slider
        public string HCreateSLider(UserRegViewmodel vModel)
        {           
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if(file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/img/Homepage/Slider/" +filename));
                vModel.Hslider_obj.image = filename;
                file.SaveAs(imgpath);
            }
            try
            {
                var searchList = new List<SearchValueData>
                     {
                         new SearchValueData { Name = "image", Value = vModel.Hslider_obj.image},
                         new SearchValueData { Name = "title", Value = vModel.Hslider_obj.title},
                         new SearchValueData { Name = "price", Value = vModel.Hslider_obj.price},
                         new SearchValueData { Name = "description", Value = vModel.Hslider_obj.description}
                     };

                DataSet userList = GetDataSet("sp_H_sli_insert", searchList);
                return "Successful Added";
            }
            catch (Exception)
            {
                return "Not Successful Added";
            }
        }

        // Update -id get
        public HomeSlider HUpdateIdSLider(Guid id)
        {
            var searchList = new List<SearchValueData>
                {
                    new SearchValueData { Name = "sid", Value = Convert.ToString(id) }
                };
            HomeSlider getinfo = GetEntity<HomeSlider>("sp_H_sli_upd_id", searchList);
            return getinfo;
        }

        // Update
        public string HUpdateSLider(HomeSlider vModel)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if (file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/img/Homepage/Slider/" + filename));
                vModel.image = filename;
                file.SaveAs(imgpath);
            }
            var searchList = new List<SearchValueData>
             {
                 new SearchValueData { Name = "sid", Value = vModel.sid.ToString()},
                 new SearchValueData { Name = "image", Value = vModel.image},
                 new SearchValueData { Name = "title", Value = vModel.title},
                 new SearchValueData { Name = "price", Value = vModel.price},
                 new SearchValueData { Name = "description", Value = vModel.description}
             };

            DataSet userList = GetDataSet("sp_H_sli_update", searchList);

            return "Successful Added";
        }

        public string HDeleteSLider(Guid id)
        {
            var searchList = new List<SearchValueData>
            {
                new SearchValueData {Name = "sid", Value = id.ToString() }
            };
            DataSet userlist = GetDataSet("sp_H_sli_delete", searchList);
            return "Record Delete Successful";
        }

    }
}   