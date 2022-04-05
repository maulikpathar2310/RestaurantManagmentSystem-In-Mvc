using Restaurantmanagment.Models.Entity;
using Restaurantmanagment.Models.Entity.Cart;
using Restaurantmanagment.Models.Entity.Registerpage;
using Restaurantmanagment.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantmanagment.Infrastructure.DataProvider
{
    interface IServiceProvider
    {
        //Table Book
        string CreateServiceProvider(UserRegViewmodel model);
        UserRegViewmodel Getbooklist();
        Booktable TableUpdIdProvider(int id);
        string TableUpdProvider(Booktable model);
        string DeletServiceProvider(int id);

        //Order cart List
        Items GetItemById(int id);
        
        //Ordered Placed 
        string OrderDataGetIns(Items model);

        //Emailverify
        string EmailVerifyPass(UserRegViewmodel verify);
    }
}
