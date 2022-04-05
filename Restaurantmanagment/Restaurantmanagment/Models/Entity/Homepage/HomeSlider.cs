using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurantmanagment.Models.Entity.Homepage
{
    [TableName("HomeSlider")]
    [PrimaryKey("sid")]
    public class HomeSlider
    {
        public Guid sid { get; set; }

        public string image { get; set; }

        public string title { get; set; }

        public string price { get; set; }

        public string description { get; set; }

        public bool IsActive { get; set; }
        public byte[] UpdateLog { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}