using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medical_shop.Models.Entities;

namespace Medical_shop.Models.Decorator
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