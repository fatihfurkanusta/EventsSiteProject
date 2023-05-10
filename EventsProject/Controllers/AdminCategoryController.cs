using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace EventsProject.Controllers
{
    public class AdminCategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        CityManager city = new CityManager(new EfCityDal());

        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p) 
        {
            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult results = categoryvalidator.Validate(p);
            if(results.IsValid)
            {
                cm.CategoryAdd(p);
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

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetByID(id);
            cm.CategoryDelete(categoryValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id) 
        {
            var categoryValue = cm.GetByID(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult CityPartial() 
        {
            var eventValues = city.GetList();
            return View(eventValues);
        }

        [HttpGet]
        public ActionResult AddCity() { return View(); }
        [HttpPost]
        public ActionResult AddCity(City p)
        {
            return View(p); 
        }
    }
}