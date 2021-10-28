using LoginandR.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LoginandR.Controllers
{
    public class UserController : Controller
    {
        private DB_Entities _db = new DB_Entities();
        // GET: User
        public ActionResult Index(int? id)
        {
            id = (int?)Session["ID"];

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            id = (int?)Session["ID"];

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "uID,uUsername,uPwd,uFirstname,uLastname,uPhone,uAddress,uBirthday,uEmail,uGender,uCreditCard,ConfirmPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User password
        public ActionResult EditPassword(int? id)
        {
            id = (int?)Session["ID"];

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPassword([Bind(Include = "uID,uUsername,uPwd,uFirstname,uLastname,uPhone,uAddress,uBirthday,uEmail,uGender,uCreditCard,ConfirmPassword")] User user)
        {
            
                if (ModelState.IsValid)
                {
                    user.uPwd = GetMD5(user.uPwd);
                user.ConfirmPassword = user.uPwd;
                    _db.Entry(user).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Login", "Home");
                }
                return View(user);
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
    }
}