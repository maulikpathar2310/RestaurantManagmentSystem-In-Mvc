using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurantmanagment.Models.Entity.Homepage
{
    [TableName("H_Bannerimg")]
    [PrimaryKey("imgid")]
    public class H_Bannerimg
    {
        public Guid imgid { get; set; }

      

        public string himage { get; set; }
    }
}