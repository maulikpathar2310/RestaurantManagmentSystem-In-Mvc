
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurantmanagment.Models
{
    public class SearchValueData
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsEqual { get; set; }
        public bool IsNotEqual { get; set; }
    }
}