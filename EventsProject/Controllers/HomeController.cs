using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventsProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        EventManager em = new EventManager(new EfEventDal());


        public ActionResult Index()
        {
            em.EventDate();
            return View();
        }

        public ActionResult Event()
        {
            return View();
        }
        public PartialViewResult PartialContent(string search)
        {
            var eventList = em.GetListByActive(search);
            return PartialView(eventList);
        }
    }
}