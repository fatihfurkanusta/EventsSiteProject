using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EventsProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        UserManager um = new UserManager(new EfUserDal());
        UserValidator userValidator = new UserValidator();

        public ActionResult Index()
        {
            var userValues = um.GetList();
            return View(userValues);
        }

        [HttpGet]
        public ActionResult AddUser() 
        { 
            return View();
        }
        
        [HttpPost]
        public ActionResult AddUser(User p)
        {
            
            ValidationResult results = userValidator.Validate(p);
            if (results.IsValid)
            {
                um.UserAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); 
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditUser(int id){
            var userValue = um.GetByID(id);
            return View(userValue);
        }

        [HttpPost]
        public ActionResult EditUser(User p)
        {
            ValidationResult results = userValidator.Validate(p);
            if (results.IsValid)
            {
                um.UserUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteUser(int id)
        {
            var userValue = um.GetByID(id);
            um.UserDelete(userValue);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult AddUser2()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddUser2(User p)
        {

            if (um.UserAdd2(p)) 
            {
                ViewBag.UserReport = "Başarılı bir şekilde kayıt oldunuz.";
            }
            else
            {
                ViewBag.UserReport = "Bu email zaten kullanılıyor.";
            }
            
            return View();
            
        }
    }
}