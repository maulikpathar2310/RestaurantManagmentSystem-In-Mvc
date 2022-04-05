using Restaurantmanagment.Models;
using Restaurantmanagment.Models.Entity;
using Restaurantmanagment.Models.Entity.Cart;
using Restaurantmanagment.Models.Entity.Registerpage;
using Restaurantmanagment.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;

namespace Restaurantmanagment.Infrastructure.DataProvider
{
    public class ServiceProvider : BaseDataProvider, IServiceProvider
    {
        //****************************************************  Book Table in contact page ***********************************************************
        //Table Book List
        public UserRegViewmodel Getbooklist()
        {
            UserRegViewmodel list = new UserRegViewmodel();
            DataSet ds = GetDataSet("sp_booktbl_select", null);
            for(int i=0; i<ds.Tables[0].Rows.Count; i++)
            {
                UserRegViewmodel newlist = new UserRegViewmodel();
                newlist.User_Bookobj.id = int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["id"]));
                newlist.User_Bookobj.name = Convert.ToString(ds.Tables[0].Rows[i]["name"]);
                newlist.User_Bookobj.email = Convert.ToString(ds.Tables[0].Rows[i]["email"]);
                newlist.User_Bookobj.phone = Convert.ToString(ds.Tables[0].Rows[i]["phone"]);
                newlist.User_Bookobj.date = Convert.ToString(ds.Tables[0].Rows[i]["date"]);
                newlist.User_Bookobj.time = Convert.ToString(ds.Tables[0].Rows[i]["time"]);
                newlist.User_Bookobj.number = int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["number"]));
                newlist.User_Bookobj.description = Convert.ToString(ds.Tables[0].Rows[i]["description"]);

                list.User_Booklist.Add(newlist.User_Bookobj);
            }

            return list;
        }

        //Table Book Create
        public string CreateServiceProvider(UserRegViewmodel model)
        {
            try
            {
                var searchlist = new List<SearchValueData>
                {
                    new SearchValueData { Name = "name", Value = model.User_Bookobj.name },
                    new SearchValueData { Name = "email", Value = model.User_Bookobj.email },
                    new SearchValueData { Name = "phone", Value = model.User_Bookobj.phone},
                    new SearchValueData { Name = "date", Value = model.User_Bookobj.date },
                    new SearchValueData { Name = "time", Value = model.User_Bookobj.time },
                    new SearchValueData { Name = "number", Value = model.User_Bookobj.number.ToString()},
                    new SearchValueData { Name = "description", Value = model.User_Bookobj.description}
                };

                DataSet userList = GetDataSet("sp_booktbl_insert", searchlist);

                return "Successful Added";
            }
            catch (Exception)
            {
                return "not Successful";
            }
        }
        // Update id
        public Booktable TableUpdIdProvider(int id)
        {
            var searchlist = new List<SearchValueData>
            {
                new SearchValueData {Name = "id", Value = Convert.ToString(id) }
            };
            Booktable getinfo = GetEntity<Booktable>("sp_booktbl_upd_id", searchlist);
            return getinfo;
        }

        // Update
        public string TableUpdProvider(Booktable model)
        {
            var searchList = new List<SearchValueData>
            {
                new SearchValueData {Name = "id", Value = model.id.ToString()},
                new SearchValueData { Name = "name", Value = model.name },
                new SearchValueData { Name = "email", Value = model.email },
                new SearchValueData { Name = "phone", Value = model.phone },
                new SearchValueData { Name = "date", Value = model.date },
                new SearchValueData { Name = "time", Value = model.time },
                new SearchValueData { Name = "number", Value = model.number.ToString() },
                new SearchValueData { Name = "description", Value = model.description }
            };
            DataSet userList = GetDataSet("sp_booktbl_update", searchList);

            return "Successful Updated";
        }

        //Table Book Delete record
        public string DeletServiceProvider(int id)
        {
            var searchList = new List<SearchValueData>
            {
                new SearchValueData {Name = "id", Value = id.ToString() }
            };
            DataSet userlist = GetDataSet("sp_booktbl_delete", searchList);
            return "Record Delete Successful";
        }

        //******************************************************** Cart Update Id *******************************************
        // Update -id get 
        public Items GetItemById(int id)
        {
            var searchList = new List<SearchValueData>
                {
                    new SearchValueData { Name = "id", Value = Convert.ToString(id) }
                    
                };

            Items getinfo = GetEntity<Items>("sp_gujcart_item_id", searchList);
            return getinfo;
        }
             

        //********************************************** Order Data Get List *************************************** 

        //------------------ Insert ----------------------
        public string OrderDataGetIns(Items model)
        {
            try
            {
                //List<Items> AuthorList = new List<Items>();
                DataTable dt = new DataTable();
                var searchlist = new List<SearchValueData>
              
                {
                    new SearchValueData { Name = "uname", Value = model.uname},
                    new SearchValueData { Name = "name", Value = model.name},
                    new SearchValueData { Name = "quantity", Value = model.quantity.ToString()},
                    new SearchValueData { Name = "price", Value = model.price},
                    new SearchValueData { Name = "amount", Value = model.amount},
                    new SearchValueData { Name = "total", Value = model.total.ToString()}                   
                };

                DataSet userList = GetDataSet("sp_itemlist_add", searchlist);

                return "Successful Added";
            }
            catch (Exception)
            {
                return "not Successful";
            }
        }
        

       
        //******************************************************** EmailVerifyPass - Forget Passsowrd ***************************************************************
        //EmailVerifyPass
        public string EmailVerifyPass(UserRegViewmodel verify)
        {
            
            var serchList = new List<SearchValueData>();
            var serchvaluedata = new SearchValueData { Name = "email", Value = verify.Email_obj.email.ToString()};           
            serchList.Add(serchvaluedata);
            //Verify Email ID            
           
            UserRegister usr_login = GetEntity<UserRegister>("sp_email_verify", serchList);
            FormsAuthentication.SetAuthCookie(verify.Email_obj.email, false);
            
            if (usr_login != null)
            {
                
                MailMessage mc = new MailMessage("maulikpathar2310@gmail.com", verify.Email_obj.email );
                mc.Subject = "Reset  Password";
                //Generate Reset Password Link
                mc.Body = "Hi,<br/>br/>We got request for reset your account password. Please click on the below link to reset your password" + "<br/><br/>  <a href='https://localhost:44391/Home/ForgetPass?id=" + usr_login.uid + "'> Click here to reset your password </a> ";
                mc.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("maulikpathar2310@gmail.com", "upprwdmkpaegdjdo");
                smtp.EnableSsl = true;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.UseDefaultCredentials = false;

                //Send Email
                smtp.Send(mc);                
                return "Success";
            }
            else
            {
                return "NOt Success";
            }
           
        }

    }
}