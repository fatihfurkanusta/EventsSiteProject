using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventsProject.Controllers
{
    public class EventController : Controller
    {
        EventManager em = new EventManager(new EfEventDal());
        AllowEventManager aem = new AllowEventManager(new EfAllowEventDal());   
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        CityManager ctm = new CityManager(new EfCityDal());
        UserManager um = new UserManager(new EfUserDal());

        public ActionResult Index()
        {
            var eventValues = em.GetList();
            return View(eventValues);
        }
        [HttpGet]
        public ActionResult AddEvent()
        {
            var categories = cm.GetList();
            var valueCategory = categories.Select(c => new SelectListItem
                                                    {
                                                        Value = c.CategoryID.ToString(),
                                                        Text = c.CategoryName
                                                    }).ToList();

            ViewBag.vlc = valueCategory;

            var cities = ctm.GetList();

            var valueCity = cities.Select(c => new SelectListItem
                                                    {
                                                        Value = c.CityName,
                                                        Text = c.CityName
                                                    }).ToList();

            ViewBag.city = valueCity;


            List<SelectListItem> valueUser = (from x in um.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.UserName + "" + x.UserSurname,
                                                  Value = x.UserID.ToString(),
                                              }).ToList();

            ViewBag.vlu = valueUser;
            return View();
        }
        [HttpPost]
        public ActionResult AddEvent(Event p)
        {
            em.EventAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            var categories = cm.GetList();
            var valueCategory = categories.Select(c => new SelectListItem
                                                {
                                                    Value = c.CategoryID.ToString(),
                                                    Text = c.CategoryName
                                                }).ToList();

            ViewBag.vlc = valueCategory;

            var cities = ctm.GetList();
            var valueCity = cities.Select(c => new SelectListItem
                                                {
                                                    Value = c.CityName,
                                                    Text = c.CityName
                                                }).ToList();

            ViewBag.city = valueCity;

            var eventValue = em.GetByID(id);
            return View(eventValue);
            
        }
        [HttpPost]
        public ActionResult EditEvent(Event p)
        {
            em.EventUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEvent(int id)
        {
            var eventValue = em.GetByID(id);
            eventValue.EventStatus = false;
            em.EventDelete(eventValue);
            return RedirectToAction("Index");
        }

        public ActionResult AllowEventPartial()
        {
            var eventValues = aem.GetListOnlyApprove();
            return View(eventValues);
        }

        public ActionResult ApproveEvent(int id)
        {
            var eventValues = aem.GetByID(id);
            eventValues.CheckStatus = true;
            eventValues.AllowEventStatus = false;
            aem.CheckAllowEvent();

            aem.AllowEventDelete(eventValues);
            
            return RedirectToAction("Index","Event");
        }

        public ActionResult RefuseEvent(int id)
        {
            var eventValues = aem.GetByID(id);
            eventValues.CheckStatus = true;

            aem.AllowEventUpdate(eventValues);

            return RedirectToAction("Index", "Event");
        }

    }
}