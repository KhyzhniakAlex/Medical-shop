using Medical_shop.Models.Entities;
using Medical_shop.Models.Services;
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
            return View();
        }

        public ActionResult Categories()
        {
            return View(db.TypeOfProducts);
        }



        [HttpGet]
        public ViewResult Products(int? id)
        {
            if (id == null)
            {
                return View("~/Views/Home/Tourniquets.cshtml");
            }

            TypeOfProduct type = db.TypeOfProducts.Find(id);
            if (type == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            type.Products = (List<Product>) db.Products.Where(m => m.TypeOfProductId == type.Id);
            ViewBag.Products = type;
            return View("~/Views/Home/Tourniquets.cshtml");
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
            return View();
        }
    }
}