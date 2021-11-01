using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using LoginandR.Models;
using System.Security.Cryptography;
using System.Net;

namespace LoginandR.Controllers
{

    public class HomeController : Controller
    {
        private DB_Entities _db = new DB_Entities();
        public ActionResult Index()
        {
            /*if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }*/
            return View();
        }
        public ActionResult Product(int? page)
        {
            var data = (from s in _db.Products select s);
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1; // set page default 1
            }
            int limit = 6; //display show 3 product 
            int start = (int)(page - 1) * limit;
            int totalProduct = data.Count();
            ViewBag.totalProduct = totalProduct;
            ViewBag.pageCurrent = page;
            float numberPage = (float)totalProduct / limit;
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var dataProduct = data.OrderByDescending(s => s.proID).Skip(start).Take(limit);
            if( page > numberPage)
            {
                return HttpNotFound();
            }
            return View(dataProduct.ToList());
        }





        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }








        public ActionResult Register()
        {
            return View();
        }
        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.Users.FirstOrDefault(s => s.uEmail == _user.uEmail);
                if (check == null)
                {
                    _user.uPwd = GetMD5(_user.uPwd);
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Users.Add(_user);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        public ActionResult Login()
        {
            return View();
        }






        [HttpPost]
        public ActionResult Login(string username, string pwd)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(pwd);
                var data = _db.Users.Where(s => s.uUsername.Equals(username) && s.uPwd.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().uFirstname + " " + data.FirstOrDefault().uLastname;
                    Session["Email"] = data.FirstOrDefault().uEmail;
                    Session["Username"] = data.FirstOrDefault().uUsername;
                    Session["ID"] = data.FirstOrDefault().uID;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        //About
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }



    }
}