using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HJ_Template_MVC.Controllers
{
    public partial class HomeController : Infrastructure.BaseController
    {
        // GET: Home
     
        public void ChangeCulture(string name)
        {
            Session["Culture"] = Request.QueryString["name"];

            //return (RedirectToAction(MVC.Home.Index()));

            string strUrlReferrer =
                Request.UrlReferrer.AbsoluteUri;

            Response.Redirect(strUrlReferrer, endResponse: false);
        }
   
    }
}