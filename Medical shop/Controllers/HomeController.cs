using Medical_shop.Models.Entities;
using Medical_shop.Models.Services;
using Medical_shop.Models.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medical_shop.Controllers
{
    public class HomeController : Controller
    {
        MedicalContext db = new MedicalContext();

        public ActionResult Main()
        {
            return View(db.Comments);
        }

        public ActionResult Categories()
        {
            ViewBag.Categories = db.TypeOfProducts;
            ViewBag.AmountOfCategories = db.TypeOfProducts.Count();
            return View(db.Comments);
        }

        public ActionResult Questions()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult Delivery()
        {
            return View();
        }

        public ActionResult Basket()
        {
            if (User.Identity.IsAuthenticated)
            {
                //var order = Order.GetInstance();
                var order = (Order)Session["Order"];

                ViewBag.Products = order.PrimaryProducts;
                return View(db.Comments);
            }
            ViewBag.Products = null;
            return View(db.Comments);
        }


        [HttpPost]
        public RedirectResult AddComment(Comment comment)
        {
            string name = User.Identity.Name;
            HomeServices.AddComment(comment, name);
            return RedirectPermanent($"/Home/{comment.Page}");
        }


        //[HttpGet]
        public ViewResult Products(int id)
        {
            TypeOfProduct type = HomeServices.GetProducts(id);
            if (type == null) return View("~/Views/Shared/Error.cshtml");

            ViewBag.Products = type.Products;
            ViewBag.AmountOfProducts = type.Products.Count();
            ViewBag.TypeName = type.Name;
            return View("~/Views/Home/Products.cshtml");
        }

        //[HttpPost]
        public ViewResult ProductsPost(int id)
        { 
            Order OrderForUser = null;
            int userID = 0;
            MedicalContext db = new MedicalContext();
            foreach (var item in db.Users)
            {
                if (item.Login == User.Identity.Name)
                    userID = item.Id;
            }
            foreach (var item in db.Orders)
            {
                if (item.UserId == userID) OrderForUser = item;
            }
            if (User.Identity.IsAuthenticated && OrderForUser == null)
            {
                var firstOrder = new Order { UserId = userID };
                db.Orders.Add(firstOrder);
                Session["Order"] = firstOrder;
                db.SaveChanges();
            }
            Session["Order"] = OrderForUser;
            HomeServices.PostProduct(id, OrderForUser);
            return View("~/Views/Home/Products.cshtml");
        }



        [HttpGet]
        public ViewResult OneProduct(int id)
        {
            PrimaryProduct product = db.PrimaryProducts.Find(id);
            if (product == null) return View("~/Views/Shared/Error.cshtml");

            ViewBag.Product = product;
            ViewBag.Comments = db.Comments;
            return View("~/Views/Home/OneProduct.cshtml");
        }

        [HttpPost]
        public ViewResult OneProductPost(int id)
        {
            Order OrderForUser = null;
            int userID = 0;
            MedicalContext db = new MedicalContext();
            foreach (var item in db.Users)
            {
                if (item.Login == User.Identity.Name)
                    userID = item.Id;
            }
            foreach (var item in db.Orders)
            {
                if (item.UserId == userID) OrderForUser = item;
            }
            if (User.Identity.IsAuthenticated && OrderForUser == null)
            {
                var firstOrder = new Order { UserId = userID };
                db.Orders.Add(firstOrder);
                Session["Order"] = firstOrder;
                db.SaveChanges();
            }
            Session["Order"] = OrderForUser;
            HomeServices.PostProduct(id, OrderForUser);
            return View("~/Views/Home/OneProduct.cshtml");
        }



        public ViewResult DeleteProductFromOrder(int id)
        {
            var order = (Order)Session["Order"];
            HomeServices.DeleteProductFromOrder(id, order);
            return View("~/Views/Home/Basket.cshtml");
        }

        [HttpPost]
        public ViewResult SaveOrder()
        {
            var order = (Order)Session["Order"];
            HomeServices.SaveOrder(order);
            Session["Order"] = new Order { UserId = db.Users.Max(p => p.Id) };
            return View("~/Views/Home/Categories.cshtml");
        }

        public ViewResult RefreshBasket()
        {
            HomeServices.RefreshBasket();
            return View("~/Views/Home/Basket.cshtml");
        }
    }
}