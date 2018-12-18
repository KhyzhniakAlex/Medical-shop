using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public class TypeOfProduct : Base
    {
        public string Name { get; set; }
        public string ImageDirection { get; set; }

        public List<PrimaryProduct> Products { get; set; }
    }
}