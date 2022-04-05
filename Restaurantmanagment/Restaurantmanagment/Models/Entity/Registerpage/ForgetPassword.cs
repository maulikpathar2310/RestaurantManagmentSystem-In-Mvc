using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurantmanagment.Models.Entity.Registerpage
{
    public class ForgetPassword
    {
        public int fid { get; set; }

        [Required(ErrorMessage = "name required")]
        public string email { get; set; }

        [Required(ErrorMessage = "name required")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string cpassword { get; set; }
    }
}