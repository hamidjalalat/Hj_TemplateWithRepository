using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infrastructure
{
    public class LogAttribute:ActionFilterAttribute
    {
        public LogAttribute() : base()
        {
            Ignore = true;
        }
        public LogAttribute(bool ignore) : base()
        {
            Ignore = ignore;
        }
        public bool Ignore { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Ignore)
            {
                string path = HttpContext.Current.Server.MapPath("~/App_Data/ActionLog.txt");
                StreamWriter oStreamWriter = new StreamWriter(path, true);
                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();
                string time = DateTime.Now.ToString();
                oStreamWriter.Write(controller + "/" + action + "/" + time + "/");
                oStreamWriter.Close();
                oStreamWriter.Dispose();
            }
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (Ignore)
            {
                string path = HttpContext.Current.Server.MapPath("~/App_Data/ActionLog.txt");
                StreamWriter oStreamWriter = new StreamWriter(path, true);
                string time = DateTime.Now.ToString();
                oStreamWriter.WriteLine(time);
                oStreamWriter.Close();
                oStreamWriter.Dispose();
            }
            base.OnResultExecuted(filterContext);
        }
    }
}