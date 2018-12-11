using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models
{
    public class Order : Base
    {
        public DateTime CreatedAt { get; set; }
        public int Sum { get; set; }

        public int ClientId { get; set; }
        //public List<Product> Products { get; set; }

        public Order(int id) : base(id) { }
    }
}