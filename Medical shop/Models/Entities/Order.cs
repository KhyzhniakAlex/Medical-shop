using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public class Order : Base
    {
        public int Sum { get; set; }
        public string Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<PrimaryProduct> PrimaryProducts { get; set; }
        public Order()
        {
            PrimaryProducts = new List<PrimaryProduct>();
        }

        //private static Order instance;

        //public static Order GetInstance()
        //{
        //    if (instance == null)
        //        instance = new Order();
        //    return instance;
        //}

        //public static Order CreateNewInstance()
        //{
        //    instance = new Order();
        //    return instance;
        //}
    }
}