using Restaurantmanagment.Models.Entity;
using Restaurantmanagment.Models.Entity.Aboutpage;
using Restaurantmanagment.Models.Entity.Cart;
using Restaurantmanagment.Models.Entity.Gallery;
using Restaurantmanagment.Models.Entity.Gujaratidish;
using Restaurantmanagment.Models.Entity.Homepage;
using Restaurantmanagment.Models.Entity.Panjabidish;
using Restaurantmanagment.Models.Entity.Registerpage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurantmanagment.Models.Viewmodel
{
    public class UserRegViewmodel
    {
        public UserRegViewmodel()
        {
            //Home - page
            HwhyRes_obj = new H_WhyChooseRes();
            HwhyRes_list = new List<H_WhyChooseRes>();

            Hbanner_obj = new H_Bannerimg();
            Hbanner_list = new List<H_Bannerimg>();

            Hslider_obj = new HomeSlider();
            Hslider_list = new List<HomeSlider>();

            //Aboutus Page
            About_obj = new Aboutus();
            About_list = new List<Aboutus>();

            //User Register          
            User_Regobj = new UserRegister();
            User_Reglist = new List<UserRegister>();

            //Table-book
            User_Bookobj = new Booktable();
            User_Booklist = new List<Booktable>();
            
            //Gujarati dish
            Guj_obj = new Gujdish();
            Guj_list = new List<Gujdish>();

            //Panjabi dish
            Pan_obj = new Panjabidish();
            Pan_list = new List<Panjabidish>();

            //Gallery dish
            Gal_obj = new Gallery();
            Gal_list = new List<Gallery>();

            //Items dish
            Item_obj = new Items();
            Item_list = new List<Items>();

            //Order
            Order_obj = new Order();
            Order_list = new List<Order>();

            //Order - Details
            Odetails_obj = new Order_details();
            Odetails_list = new List<Order_details>();

            //Email Verify
            Email_obj = new EmailVerifyPass();
            Email_list = new List<EmailVerifyPass>();

            //Forget Password
            ForgetP_obj = new ForgetPassword();
            ForgetP_list = new List<ForgetPassword>();

        }

        //Home - page
        public H_WhyChooseRes HwhyRes_obj { get; set; }
        public List<H_WhyChooseRes> HwhyRes_list { get; set; }

        public H_Bannerimg Hbanner_obj { get; set; }
        public List<H_Bannerimg> Hbanner_list { get; set; }

        public HomeSlider Hslider_obj { get; set; }
        public List<HomeSlider> Hslider_list { get; set; }

        //Aboutus Page
        public Aboutus About_obj { get; set; }
        public List<Aboutus> About_list { get; set; }

        //User-Register
        public UserRegister User_Regobj { get; set; }
        public List<UserRegister> User_Reglist { get; set; }

        //Table-book
        public Booktable User_Bookobj { get; set; }
        public List<Booktable> User_Booklist { get; set; }

        //Gujarati dish
        public Gujdish Guj_obj { get; set; }
        public List<Gujdish> Guj_list { get; set; }

        //Panjabi dish
        public Panjabidish Pan_obj { get; set; }
        public List<Panjabidish> Pan_list { get; set; }

        //Gallery dish
        public Gallery Gal_obj { get; set; }
        public List<Gallery> Gal_list { get; set; }

        //Items
        public Items  Item_obj { get; set; }
        public List<Items> Item_list { get; set; }

        //Order
        public Order Order_obj { get; set; }
        public List<Order> Order_list { get; set; }

        //Order - Details
        public Order_details Odetails_obj { get; set; }
        public List<Order_details> Odetails_list { get; set; }

        //Email Verify
        public EmailVerifyPass Email_obj { get; set; }
        public List<EmailVerifyPass> Email_list { get; set; }

        //Forget Password
        public ForgetPassword ForgetP_obj { get; set; }
        public List<ForgetPassword> ForgetP_list { get; set; }

    }
}