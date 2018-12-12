using Medical_shop.Models.Entities;
using Medical_shop.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medical_shop.Controllers
{
    public class AuthorityController : Controller
    {
        // GET: Authority
        public ActionResult Log_in()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }
    }
}