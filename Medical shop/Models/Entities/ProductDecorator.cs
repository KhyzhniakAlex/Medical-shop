using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public abstract class ProductDecorator : Product
    {
        protected Product product;

        public ProductDecorator(Product product)
        {
            this.product = product;
        }
    }
}