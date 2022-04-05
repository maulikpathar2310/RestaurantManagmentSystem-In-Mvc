using Restaurantmanagment.Models.Entity;
using Restaurantmanagment.Models.Entity.Aboutpage;
using Restaurantmanagment.Models.Entity.Gallery;
using Restaurantmanagment.Models.Entity.Gujaratidish;
using Restaurantmanagment.Models.Entity.Homepage;
using Restaurantmanagment.Models.Entity.Panjabidish;
using Restaurantmanagment.Models.Entity.Registerpage;
using Restaurantmanagment.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Restaurantmanagment.Infrastructure.DataProvider
{
    interface IAdminProvider
    {

        //======================== User-Register ========================
        Login UserLogin(Login login);
        string UserCreate(UserRegViewmodel vModel);
        UserRegViewmodel UserList();
        UserRegister UserUpdateId(Guid id);
        string UserUpdate(UserRegister model);
        string UserDelete(Guid id);

        ///==================== About Us Page ===========================
        UserRegViewmodel AboutusList();
        string AboutusCreate(UserRegViewmodel vModel);
        Aboutus AboutusUpdateId(Guid id);
        string AboutusUpdate(Aboutus Model);
        string AboutusDelete(Guid id);

        //==================== Gujarati thali ===========================
        string CreateGujProvider(UserRegViewmodel vModel);
        UserRegViewmodel Getgujlist();
        Gujdish UpdIdGujProvider(int id);
        string UpdGujProvider(Gujdish vModel);
        string DeleteGujProvider(int id);

        //==================== Panjabi thali ===========================
        string PanjabiCreate(UserRegViewmodel model);
        UserRegViewmodel PanjabiList();
        Panjabidish PanjabiUpdateId(int pid);
        string PanjabiUpdate(Panjabidish Model);
        string PanjabiDelete(int pid);

        ///==================== Order Placed ===========================
        UserRegViewmodel OrderDataSerList();
        string OrderDataSerDelete(int id);

        //==================== Gallery Page ===========================
        UserRegViewmodel GalleryList();
        string GalleryCreate(UserRegViewmodel vModel);
        Gallery GalleryUpdateId(Guid id);
        string GalleryyUpdate(Gallery Model);
        string GalleryDelete(Guid id);

        //Home page ====== Banner Section  ==============================
        string HBanCreatePro(UserRegViewmodel vModel);
        string HBanDeletePro(Guid id);

        //Home page ====== Why choose our Restaurant ====================
        string HCreateWhyProvider(UserRegViewmodel vModel);
        UserRegViewmodel HSelWhyProvider();
        H_WhyChooseRes HUpdateIdWhyProvider(Guid id);
        string HUpdateWhyProvider(H_WhyChooseRes vModel);
        string HDeleteWhyProvider(Guid id);

        //Home page =================== Slider ==========================
        string HCreateSLider(UserRegViewmodel vModel);
        HomeSlider HUpdateIdSLider(Guid id);
        string HUpdateSLider(HomeSlider vModel);
        string HDeleteSLider(Guid id);

    }
}
