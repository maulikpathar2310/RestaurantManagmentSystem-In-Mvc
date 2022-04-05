using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurantmanagment.Models.Entity.Registerpage
{
    public class Login
    {
        public Guid id { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

       
        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }
        public byte[] UpdateLog { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}