using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Medical_shop.Models.Entities;

namespace Medical_shop.Models.Services
{
    public class MedicalDbInitializer : DropCreateDatabaseAlways<MedicalContext>
    {
        protected override void Seed(MedicalContext context)
        {
            context.Users.Add(new User { Login = "Khyzhniak", Email = "khyzhniak@i.ua", Password = "020299", Date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss"), Role = "client" });
            context.Users.Add(new User { Login = "Konorin", Email = "khyzhniak@i.ua", Password = "030399", Date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss"), Role = "admin" });

            //context.Comments.Add(new Comment { Text = "Good site", Date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss"), Page = "Main", UserId = 1 });
            //context.Comments.Add(new Comment { Text = "Course work", Date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss"), Page = "Main", UserId = 2 });
            //    Order order1 = new Order
            //    {
            //        Date = new DateTime().ToString("dd'/'MM'/'yyyy HH':'mm':'ss"),
            //        Sum = 399,
            //        UserId = 1
            //    };
            //    Order order2 = new Order
            //    {
            //        Date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss"),
            //        Sum = 618,
            //        UserId = 1
            //    };
            //    Order order3 = new Order
            //    {
            //        Date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH':'mm':'ss"),
            //        Sum = 2000,
            //        UserId = 2
            //    };
            //    context.Orders.Add(order1);
            //    context.Orders.Add(order2);
            //    context.Orders.Add(order3);

            context.TypeOfProducts.Add(new TypeOfProduct { Name = "Аптечки", ImageDirection = "~/Images/aid kit.jpg" });
            context.TypeOfProducts.Add(new TypeOfProduct { Name = "Артеріальні джгути", ImageDirection = "~/Images/arterial harnesses.jpg" });

            context.SaveChanges();

            PrimaryProduct product1 = new PrimaryProduct
            {
                Name = "Тримач для турнікета",
                Price = 219,
                Amount = 10,
                Sale = "20",
                ImageDirection = "~/Images/holder fot the tourniquet.jpg",
                Text = "",
                TypeOfProductId = 2
                //Orders = new List<Order>() { order1, order2 }
            };
            PrimaryProduct product2 = new PrimaryProduct
            {
                Name = "Турнікет СІЧ",
                Price = 299,
                Amount = 20,
                Sale = "40",
                ImageDirection = "~/Images/tourniquet SICH.jpg",
                Text = "",
                TypeOfProductId = 2
                //Orders = new List<Order>() { order1, order3 }
            };
            PrimaryProduct product3 = new PrimaryProduct
            {
                Name = "Джгут SWAT",
                Price = 399,
                Amount = 5,
                Sale = "0",
                ImageDirection = "~/Images/tourniquet swat.jpg",
                Text = "",
                TypeOfProductId = 2
                //Orders = new List<Order>() { order1, order3 }
            };

            context.PrimaryProducts.Add(product1);
            context.PrimaryProducts.Add(product2);
            context.PrimaryProducts.Add(product3);

            //    context.RulesForAdmin.Add(new RuleForAdmin { RulePassword = "123456789" });

            context.SaveChanges();
        }
    }
}