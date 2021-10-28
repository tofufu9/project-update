using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace LoginandR.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            if ((Session["Fullname"]) != null)
            {
                return View();
            }
            else
                return RedirectToAction("Error");
        }
    }
}