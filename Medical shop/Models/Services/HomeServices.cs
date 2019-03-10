using Medical_shop.Models.Entities;
using Medical_shop.Models.Decorator;
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

        public static void PostProduct(int id, Order order)
        {
            PrimaryProduct product = db.PrimaryProducts.Find(id);
            Product productSale;
            //var order = Order.GetInstance();
            switch(product.Sale)
            {
                case "20":
                    productSale = product;
                    productSale = new Sale20Percent(productSale);
                    order.Sum += productSale.GetCost(product);
                    break;
                case "40":
                    productSale = product;
                    productSale = new Sale40Percent(productSale);
                    order.Sum += productSale.GetCost(product);
                    break;
                case "0":
                    order.Sum += product.Price;
                    break;
            }
            order.PrimaryProducts.Add(product);
            product.Orders.Add(order);
            var a = db.Orders.Find(order.Id);
            if (a == null)
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
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


        public static void AddComment(Comment comment, string name)
        {
            comment.Date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss");
            foreach (var item in db.Users)
            {
                if (item.Login == name)
                {
                    comment.UserId = item.Id;
                    item.Comments.Add(comment);
                }
            }
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