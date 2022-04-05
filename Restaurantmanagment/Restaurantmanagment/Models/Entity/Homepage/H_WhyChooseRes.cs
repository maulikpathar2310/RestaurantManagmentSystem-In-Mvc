using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Restaurantmanagment.Models.Entity.Homepage
{
    [TableName("H_WhyChooseRes")]
    [PrimaryKey("wid")]
    public class H_WhyChooseRes
    {        
        public Guid wid { get; set; }
        
        public string wnumber { get; set; }
       
        public string wtitle { get; set; }
        
        public string wdescription { get; set; }

        public bool IsActive { get; set; }
        public byte[] UpdateLog { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}