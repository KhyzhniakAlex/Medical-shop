using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public class Product : Base
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string ImageDirection1 { get; set; }
        public string ImageDirection2 { get; set; }
        public string ImageDirection3 { get; set; }
        public string Text { get; set; }

        public int TypeOfProductId { get; set; }
        public TypeOfProduct TypeOfProduct { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Product()
        {
            Orders = new List<Order>();
        }
    }
}