using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public class PrimaryProduct : Product
    {
        public int TypeOfProductId { get; set; }
        public TypeOfProduct TypeOfProduct { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public PrimaryProduct()
        {
            Orders = new List<Order>();
        }

        public override int GetCost(PrimaryProduct primary)
        {
            return primary.Price;
        }
    }
}