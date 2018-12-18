using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public abstract class Product : Base
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string Sale { get; set; }
        public string ImageDirection { get; set; }
        public string Text { get; set; }

        public abstract int GetCost(PrimaryProduct primary);
    }
}