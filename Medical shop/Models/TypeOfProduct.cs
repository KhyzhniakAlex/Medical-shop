using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models
{
    public class TypeOfProduct : Base
    {
        public string Name { get; set; }
        public string ImageDirection { get; set; }

        public List<Product> Products { get; set; }

        public TypeOfProduct(int id) : base(id) { }
    }
}