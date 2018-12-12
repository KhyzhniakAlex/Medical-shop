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
        //protected override void Seed(MedicalContext context)
        //{
        //    context.Clients.Add(new Client { Name = "Khyzhniak", Date = new DateTime().ToString("dd-MM-yyyy"), Email = "khyzhni@i.ua" });
        //    context.Clients.Add(new Client { Name = "Konorin", Date = new DateTime().ToString("dd-MM-yyyy"), Email = "bogdaner@i.ua" });

        //    context.Comments.Add(new Comment { Text = "Good site", Date = new DateTime().ToString("dd-MM-yyyy"), Page = "Main", ClientId = 1 });

        //    Order order1 = new Order
        //    {
        //        Date = new DateTime().ToString("dd-MM-yyyy"),
        //        Sum = 399,
        //        ClientId = 1
        //    };
        //    Order order2 = new Order
        //    {
        //        Date = new DateTime().ToString("dd-MM-yyyy"),
        //        Sum = 618,
        //        ClientId = 1
        //    };
        //    Order order3 = new Order
        //    {
        //        Date = new DateTime().ToString("dd-MM-yyyy"),
        //        Sum = 2000,
        //        ClientId = 2
        //    };
        //    context.Orders.Add(order1);
        //    context.Orders.Add(order2);
        //    context.Orders.Add(order3);

        //    context.TypeOfProducts.Add(new TypeOfProduct { Name = "Аптечки", ImageDirection = "~/Images/aid kit.jpg" });
        //    context.TypeOfProducts.Add(new TypeOfProduct { Name = "Артеріальні джгути", ImageDirection = "~/Images/arterial harnesses.jpg" });

        //    Product product1 = new Product
        //    {
        //        Name = "Тримач для турнікета",
        //        ImageDirection = "~/Images/holder fot the tourniquet.jpg",
        //        Price = 219,
        //        Amount = 10,
        //        TypeOfProductId = 1,
        //        Orders = new List<Order>() { order1, order2 }
        //    };
        //    Product product2 = new Product
        //    {
        //        Name = "Турнікет СІЧ",
        //        ImageDirection = "~/Images/tourniquet SICH.jpg",
        //        Price = 299,
        //        Amount = 20,
        //        TypeOfProductId = 1,
        //        Orders = new List<Order>() { order1, order3 }
        //    };

        //    context.Products.Add(product1);
        //    context.Products.Add(product2);

        //    context.SaveChanges();
        //}
    }
}