using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventsProject.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: UserPanel
        EventManager em = new EventManager(new EfEventDal());
        AllowEventManager aem = new AllowEventManager(new EfAllowEventDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        UserManager um = new UserManager(new EfUserDal());
        CityManager ctm = new CityManager(new EfCityDal());
        TicketManager tm = new TicketManager(new EfTicketDal());

        UserValidator userValidator = new UserValidator();

        Context c = new Context();


        public ActionResult Index()
        {
            var eventValues = em.GetList();
            return View(eventValues);
        }
        [HttpGet]
        public ActionResult UserProfile(int id=1)
        {
            string p = (string)Session["UserName"];
            id = c.Users.Where(x => x.UserName == p).Select(y => y.UserID).FirstOrDefault();
            var userValue = um.GetByID(id);
            return View(userValue);
        }
        [HttpPost]
        public ActionResult UserProfile(User p)
        {
            ValidationResult results = userValidator.Validate(p);
            if (results.IsValid)
            {
                um.UserUpdate(p);
                return RedirectToAction("UserProfile");
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

        public ActionResult MyTicket(string p)
        {
            p = (string)Session["UserName"];
            var userIdInfo = c.Users.Where(x => x.UserName == p).Select(y => y.UserID).FirstOrDefault();

            var values = tm.GetListByUser(userIdInfo);

            return View(values);
        }

        public ActionResult MyEvent(string p)
        {

            p = (string)Session["UserName"];
            var userIdInfo = c.Users.Where(x=> x.UserName == p).Select(y=>y.UserID).FirstOrDefault();
            var values = em.GetListByUser(userIdInfo);
            return View(values);
        }
        public PartialViewResult UserProfilePartial()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult NewEvent()
        {   
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString(),
                                                  }).ToList();
            List<SelectListItem> valueCity = (from x in ctm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CityName,
                                                  Value = x.CityName,
                                              }).ToList();
            ViewBag.city = valueCity;
            ViewBag.vlc = valueCategory;
            return View();
        }
        [HttpPost]  
        public ActionResult NewEvent(AllowEvent p)
        {
            string username = (string)Session["UserName"];
            var userIdInfo = c.Users.Where(x => x.UserName == username).Select(y => y.UserID).FirstOrDefault();
           

            p.UserID = userIdInfo;
            p.AllowEventStatus = true;
            p.CheckStatus = false;
            aem.AllowEventAdd(p);

            return RedirectToAction("MyEvent");
        }

        [HttpGet]
        public ActionResult EditEvent(int id)
        {

            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString(),
                                                  }).ToList();

            var cities = ctm.GetList();

            var valueCity = cities.Select(c => new SelectListItem
                                                    {
                                                        Value = c.CityName,
                                                        Text = c.CityName
                                                    }).ToList();

            ViewBag.city = valueCity;
            ViewBag.vlc = valueCategory;

            var eventValue = em.GetByID(id);
            return View(eventValue);

        }
        [HttpPost]
        public ActionResult EditEvent(Event p)
        {
            string username = (string)Session["UserName"];
            var userIdInfo = c.Users.Where(x => x.UserName == username).Select(y => y.UserID).FirstOrDefault();


            p.UserID = userIdInfo;
            p.EventStatus= true;
            em.EventUpdate(p);
            //if (em.EventUpdate2(p))
            //{
            //    return RedirectToAction("MyEvent");
            //}
            //else 
            //{
            //    ViewBag.UpdateError = "Etkinliğe son 5 gün kaldığı için değişiklik yapamazsınız.";
            //}
            return View();
        }


    }
}