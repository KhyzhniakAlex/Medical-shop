﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public class Sale40Percent : ProductDecorator
    {
        public Sale40Percent(Product product) : base(product)
        { }

        public override int GetCost(PrimaryProduct primary)
        {
            int price = product.GetCost(primary);
            int sale = (int)(price * 0.4);
            return price - sale;
        }
    }
}