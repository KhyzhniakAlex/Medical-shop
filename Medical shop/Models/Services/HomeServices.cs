using Medical_shop.Models.Entities;
using Medical_shop.Models.Authority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;

namespace Medical_shop.Models.Services
{
    public class HomeServices
    {
        private static MedicalContext db = new MedicalContext();

        public static TypeOfProduct GetProducts(int id)
        {
            TypeOfProduct type = db.TypeOfProducts.Find(id);
            if (type == null) return type;

            type.Products = db.PrimaryProducts
                              .AsNoTracking()
                              .Where(m => m.TypeOfProductId == type.Id)
                              .ToList();
            return type;
        }

        public static void PostProduct(PrimaryProduct pp, Order order)
        {
            PrimaryProduct product = db.PrimaryProducts.Find(pp.Id);

            //var order = Order.GetInstance();

            order.Sum += product.Price;
            order.PrimaryProducts.Add(product);

            if (db.Orders.Find(order.Id) == null) db.SaveChanges();
            else
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void SaveOrder(Order order)
        {
            //var order = Order.GetInstance();
            order.Date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss");

            if (db.Orders.Find(order.Id) != null)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteProductFromOrder(int id, Order order)
        {
            //var order = Order.GetInstance();

            foreach (var product in order.PrimaryProducts)
            {
                if (product.Id == id) order.PrimaryProducts.Remove(product);
            }
        }

        public static void RefreshBasket()
        {

        }


        public static void AddComment(Comment comment)
        {
            comment.Date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss");
            db.Comments.Add(comment);
            db.SaveChanges();
        }



        //Authority

        //public LoginModel Login(LoginModel model, bool check)
        //{
            

        //    return model;
        //}

        //public RegistrationModel Registration(RegistrationModel model, bool check)
        //{
            

        //    return model;
        //}
    }
}