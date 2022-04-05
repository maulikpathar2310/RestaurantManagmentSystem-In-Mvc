using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurantmanagment.Models.Entity.Registerpage
{
    [TableName("UserRegister")]
    [PrimaryKey("uid")]
    public class UserRegister
    {   
        
        public Guid uid { get; set; }

        [Required(ErrorMessage = "name required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Email are required")]
        [EmailAddress]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string cpassword { get; set; }

        [Required(ErrorMessage = "Phone Number required")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Address required")]
        public string address { get; set; }

        [Required(ErrorMessage = "Address required")]
        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }
        public byte[] UpdateLog { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}