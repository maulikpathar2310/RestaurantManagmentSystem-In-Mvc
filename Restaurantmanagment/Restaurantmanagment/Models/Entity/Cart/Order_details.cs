using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurantmanagment.Models.Entity.Cart
{
    [TableName("Order_details")]
    [PrimaryKey("order_details_id")]
    public class Order_details
    {
        public int order_id { get; set; }

        [Required]
        public int order_details_id { get; set; }

        [Required]
        public int pro_id { get; set; }

        [Required]
        public string pro_name { get; set; }

        [Required]
        public int pro_quantity { get; set; }

        [Required]
        public int pro_amount { get; set; }

        public bool IsActive { get; set; }
        public byte[] UpdateLog { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}