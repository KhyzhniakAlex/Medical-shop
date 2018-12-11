using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models
{
    public class Order : Base
    {
        public string Date { get; set; }
        public int Sum { get; set; }

        public int ClientId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public Order(int id) : base(id)
        {
            Products = new List<Product>();
        }
    }
}