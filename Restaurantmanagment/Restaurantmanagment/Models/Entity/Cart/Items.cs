using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurantmanagment.Models.Entity.Cart
{
    public class Items
    {
        public int id { get; set; }

        [Required]
        public string uname { get; set; }

        [Required]
        public string image { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public string price { get; set; }

        [Required]
        public string amount { get; set; }

        [Required]
        public int total { get; set; }

        public bool IsActive { get; set; }
        public byte[] UpdateLog { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}