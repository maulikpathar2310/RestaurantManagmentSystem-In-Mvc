using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurantmanagment.Models.Entity.Aboutpage
{
    [TableName("Aboutus")]
    [PrimaryKey("aid")]
    public class Aboutus
    {
        public Guid aid { get; set; }

        [Required]
        public string image { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string role { get; set; }

        [Required]
        public string fb { get; set; }

        [Required]
        public string insta { get; set; }

        public bool IsActive { get; set; }
        public byte[] UpdateLog { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}