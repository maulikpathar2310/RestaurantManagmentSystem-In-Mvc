using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Restaurantmanagment.Models.Entity
{
    [TableName("Tablebook")]
    public class Booktable
    {
        public int id { get; set; }

        [Required(ErrorMessage = "USer name required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Email name required")]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public string date { get; set; }

        [Required]
        public string time { get; set; }

        [Required]
        public int number { get; set; }

        [Required]
        public string description { get; set; }
    }
}