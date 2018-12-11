using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models
{
    public class Product : Base
    {
        public string Name { get; set; }
        public string ImageDirection { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public int TypeOfProductId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Product(int id) : base(id)
        {
            Orders = new List<Order>();
        }
    }
}