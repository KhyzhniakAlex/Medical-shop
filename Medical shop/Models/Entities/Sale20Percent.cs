using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public class Sale20Percent : ProductDecorator
    {
        public Sale20Percent(Product product) : base(product)
        { }

        public override int GetCost(PrimaryProduct primary)
        {
            int price = product.GetCost(primary);
            int sale = (int)(price * 0.2);
            return price - sale;
        }
    }
}