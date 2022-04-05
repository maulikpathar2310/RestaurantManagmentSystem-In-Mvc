using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Restaurantmanagment.Models.Entity.Gujaratidish
{
    [TableName("GujDish")]
    [PrimaryKey("id")]
    public class Gujdish
    {
        public int id { get; set; }

        [Required]
        public string gimage { get; set; }

        [Required]
        public string gname { get; set; }

        [Required]
        public string gprice { get; set; }

        public bool IsActive { get; set; }
        public byte[] UpdateLog { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}