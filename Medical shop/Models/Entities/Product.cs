using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public class Product : Base
    {
        public string Name { get; set; }
        public string ImageDirection { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public int TypeOfProductId { get; set; }
        public TypeOfProduct TypeOfProduct { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Product()
        {
            Orders = new List<Order>();
        }
    }
}