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
        public ViewResult AddComment(Comment comment)
        {
            HomeServices.AddComment(comment);
            return View($"~/Views/Home/{comment.Page}.cshtml");
        }


        [HttpGet]
        public ViewResult Products(int id)
        {
            TypeOfProduct type = HomeServices.GetProducts(id);
            if (type == null) return View("~/Views/Shared/Error.cshtml");

            ViewBag.Products = type;
            ViewBag.TypeName = type.Name;
            return View("~/Views/Home/Products.cshtml");
        }

        [HttpPost]
        public void Products(PrimaryProduct pp)
        {
            var order = (Order)Session["Order"];
            HomeServices.PostProduct(pp, order);
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
        public void OneProduct(PrimaryProduct pp)
        {
            var order = (Order)Session["Order"];
            HomeServices.PostProduct(pp, order);
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