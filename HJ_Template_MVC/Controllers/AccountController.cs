using Infrastructure;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HJ_Template_MVC.Controllers
{
    public partial class AccountController : Infrastructure.BaseController
    {

        // GET: Account
        public virtual ActionResult Login()
        {
            return View();
        }
   
        [HttpPost]
        public virtual ActionResult Login(string username, string password, string Remember)
        {
            Hash oHash = new Hash();
            string HashPassword = oHash.GetCreateHash(password.Trim());
            bool RememberMe = false;
            RememberMe = Remember != null ? true : false;
            var Result = db.Users
                .Where(current => current.Name == username.Trim() && current.Password ==HashPassword)
                .FirstOrDefault()
                ;
            if (Result != null)
            {
                System.Web.Security.FormsAuthentication
                                   .RedirectFromLoginPage(username,
                                   createPersistentCookie: RememberMe);
                var hc = new HttpCookie("currentuser", username);
                hc.Expires = DateTime.Now.AddDays(2);
                Response.SetCookie(hc);
            }
            else
            {
                ViewBag.MessageCheck = Resources.General.InvalidUserName;
            }
            return View();
        }

        public virtual ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session["UserName"] = null;
            if (Request.Cookies["currentuser"] != null)
            {
                Response.Cookies["currentuser"].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Login");
        }
        public virtual JsonResult CheckUsername(string name)
        {
            bool blnResult = true;
            var oUser = db.Users
                .Where(current => current.Name == name)
                .FirstOrDefault()
                ;
            if (oUser != null)
            {
                blnResult = false;
            }
            return Json(blnResult, JsonRequestBehavior.AllowGet);
        }
    }
}