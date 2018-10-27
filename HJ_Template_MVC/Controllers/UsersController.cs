using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModels.Users;
using Infrastructure;

namespace HJ_Template_MVC.Controllers
{
    [Authorize]
    //[Infrastructure.Log]
    public partial class UsersController : Infrastructure.BaseController
    {
        public UsersController(DAL.IUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
        }
        // GET: Users
        public virtual ViewResult Index()
        {
         
            var users = db.Users
                .OrderBy(current => current.Name)
               .ToList()
               ;
            return (View(users));
        }

        // GET: Users/Details/5
        public virtual ActionResult Details(Guid? id)
        {
            if (id.HasValue == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users
                .Where(current => current.Id == id)
                .FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(model: user);
        }
        [AllowAnonymous]
        public virtual ViewResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public virtual ActionResult Create( User user)
        {
    
            if (string.Compare(user.Name, "Hjalalat") ==0)
            {
                ModelState.AddModelError(key:"Name", errorMessage: "Some error message!");
            }
            
            if (ModelState.IsValid)
            {
                Hash oHash = new Hash();
                user.Password = oHash.GetCreateHash(user.Password);
                user.DataCreate = DateTime.Now;
                MyUnitOfWork.UserRepository.Insert(user);
                MyUnitOfWork.Save();
                //db.Users.Add(user);
                //db.SaveChanges();
                return RedirectToAction(MVC.Users.Index());
            }
            return View(user);
        }
        [HttpPost]
        public virtual JsonResult CreateAjax(User user)
        {
            //System.Threading.Thread.Sleep(1000);
            bool success = false;

            if (string.Compare(user.Name, "Hjalalat") == 0)
            {
                ModelState.AddModelError(key: "Name", errorMessage: "Some error message!");
            }

            if (ModelState.IsValid)
            {
                Hash oHash = new Hash();
                user.Password = oHash.GetCreateHash(user.Password);
                user.DataCreate = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
                success = true;
            }

            return (Json(new { success = success },
                JsonRequestBehavior.AllowGet));
        }

        // GET: Users/Edit/5
        public virtual ActionResult Edit(Guid? id)
        {
        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user =
                db.Users
                .Where(current => current.Id == id)
                .FirstOrDefault()
                ;
            EditViewModel EditViewModel = new EditViewModel();
            EditViewModel.Id = user.Id;
            EditViewModel.Name = user.Name;

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(EditViewModel);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Exclude ="googoli_magooli")] CreateViewModel user)
        {
        
            User orginalUser =
                db.Users
                .Where(current => current.Id == user.Id)
                .FirstOrDefault();
            if (orginalUser == null)
            {
                return (HttpNotFound());
            }
            //foreach (var key in ModelState.Keys.ToList().Where(key => ModelState.ContainsKey("Name")))
            //{
            //    //ModelState.Remove(key);
            //    ModelState[key].Errors.Clear();
            //}
            if (ModelState.IsValid)
            {
                orginalUser.Name = user.Name;
                orginalUser.Password = user.Password;
                orginalUser.DataCreate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction(MVC.Users.Index());
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public virtual ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users
                .Where(current=>current.Id==id)
                .FirstOrDefault()
                ;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public virtual ActionResult DeleteConfirmed(int id)
        //{
        //    User user = db.Users
        //        .Where(current=>current.Id== id)
        //        .FirstOrDefault()
        //        ;
        //    db.Users.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction(MVC.Users.Index());
        //}
        public virtual JsonResult DeleteAJAX(Guid id)
        {
            //System.Threading.Thread.Sleep(5000);
            User user = db.Users.Where(p => p.Id == id).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("user Not Found!");
                //return Json("Person not found!", JsonRequestBehavior.AllowGet);
            }
            try
            {
                db.Users.Remove(user);
                db.SaveChanges();
                //PageMessages.Add(new Infrastructure.PageMessages(Infrastructure.PageMessages.Types.Error, "{0} deleted"+user.Name));
                return Json(new { Succeed = true, Message = string.Format("{0} deleted", user.Name), Id = id });
            }
            catch (Exception ex)
            {
                return Json(new { Succeed = false, Message = "user not deleted!" + ex.Message, Id = id });
            }
        }
     
    }
}
