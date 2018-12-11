using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models
{
    public abstract class Base
    {
        public int Id { get; set; }

        public Base(int id)
        {
            this.Id = id;
        }
    }
}