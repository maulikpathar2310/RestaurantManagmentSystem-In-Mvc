using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurantmanagment.Models.Entity.Cart
{
    [TableName("Order")]
    [PrimaryKey("order_id")]
    public class Order
    {
        public int order_id { get; set; }

        [Required]
        public int total_amount { get; set; }

        [Required]
        public string is_paid { get; set; }

        [Required]
        public string order_date { get; set; }

        [Required]
        public string shipping_date { get; set; }

        [Required]
        public string delivery_date { get; set; }

        public bool IsActive { get; set; }
        public byte[] UpdateLog { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}