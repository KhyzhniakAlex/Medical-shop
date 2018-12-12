using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public class Order : Base
    {
        public string Date { get; set; }
        public int Sum { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public Order()
        {
            Products = new List<Product>();
        }
    }
}