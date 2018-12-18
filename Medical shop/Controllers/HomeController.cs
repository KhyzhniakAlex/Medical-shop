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




        [HttpGet]
        public ViewResult Products(int? id)
        {
            if (id == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            TypeOfProduct type = db.TypeOfProducts.Find(id);
            TypeOfProduct typeOne = type;
            if (type == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            type.Products = (List<PrimaryProduct>) db.PrimaryProducts.AsNoTracking().Where(m => m.TypeOfProductId == type.Id);
            ViewBag.Products = type;
            ViewBag.TypeName = typeOne.Name;
            return View("~/Views/Home/Tourniquets.cshtml");
        }



        [HttpGet]
        public ViewResult OneProduct(int? id)
        {
            if (id == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            PrimaryProduct product = db.PrimaryProducts.Find(id);
            if (product == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            ViewBag.Product = product;
            return View("~/Views/Home/OneProduct.cshtml");
        }
    }
}