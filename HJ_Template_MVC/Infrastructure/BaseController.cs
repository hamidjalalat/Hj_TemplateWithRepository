using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure
{
    public class BaseController : System.Web.Mvc.Controller
    {
        public BaseController()
         : base()
        {
        }

        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {

            if (Session["Culture"] == null)
            {
                // دستورات ذیل یعنی اول بسم الله سایت به چه زبانی دیده شود
                //Session["Culture"] = "en-US";
                Session["Culture"] = "fa-IR";
            }

            System.Globalization.CultureInfo oCultureInfo =
                new System.Globalization.CultureInfo(Session["Culture"].ToString());

            System.Threading.Thread.CurrentThread.CurrentCulture = oCultureInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = oCultureInfo;
            // **************************************************
        }
        private List<PageMessages> _pageMessages;
        protected List<PageMessages> PageMessages
        {
            get
            {
                if (_pageMessages == null)
                {
                    _pageMessages =
                        new List<PageMessages>();
                    ViewBag.Messages = _pageMessages;
                }
                return (_pageMessages);
            }

        }
        private Models.DataBaseContext _myDatabaseContext;
        protected Models.DataBaseContext db
        {
            get
            {
                if (_myDatabaseContext == null)
                {
                    _myDatabaseContext =
                        new Models.DataBaseContext();
                }

                return (_myDatabaseContext);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_myDatabaseContext != null)
                {
                    _myDatabaseContext.Dispose();
                    _myDatabaseContext = null;
                }
            }

            base.Dispose(disposing);
        }
        public BaseController(DAL.IUnitOfWork unitOfWork)
        : base()
        {
            _myUnitOfWork = unitOfWork;
        }

        private DAL.IUnitOfWork _myUnitOfWork;

        protected DAL.IUnitOfWork MyUnitOfWork
        {
            get
            {
                if (_myUnitOfWork == null)
                {
                    _myUnitOfWork =
                        new DAL.UnitOfWork();
                }

                return (_myUnitOfWork);
            }
        }

    }
}