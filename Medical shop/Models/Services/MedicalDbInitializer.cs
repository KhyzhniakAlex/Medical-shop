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
        //    context.Users.Add(new User { Login = "Khyzhniak", Password = "020299", Date = new DateTime().ToString("dd-MM-yyyy"), Role = "client", isActive = false });
        //    context.Users.Add(new User { Login = "Konorin", Password = "030399", Date = new DateTime().ToString("dd-MM-yyyy"), Role = "admin", isActive = false });

        //    context.Comments.Add(new Comment { Text = "Good site", Date = new DateTime().ToString("dd-MM-yyyy"), Page = "Main", UserId = 1 });

        //    Order order1 = new Order
        //    {
        //        Date = new DateTime().ToString("dd-MM-yyyy"),
        //        Sum = 399,
        //        UserId = 1
        //    };
        //    Order order2 = new Order
        //    {
        //        Date = new DateTime().ToString("dd-MM-yyyy"),
        //        Sum = 618,
        //        UserId = 1
        //    };
        //    Order order3 = new Order
        //    {
        //        Date = new DateTime().ToString("dd-MM-yyyy"),
        //        Sum = 2000,
        //        UserId = 2
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

        //    context.RulesForAdmin.Add(new RuleForAdmin { RulePassword = "123456789", isFree = false, UserId = 2 });

        //    base.Seed(context);
        //}
    }
}