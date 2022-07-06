using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalog_Online.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignOff()
        {
            Session["Users"] = null;
            return RedirectToAction("Login", "Users");
        }
    }
}