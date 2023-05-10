using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventsProject.Controllers
{
    public class TicketController : Controller
    {
        
        TicketManager tm = new TicketManager(new EfTicketDal());
        EventManager em = new EventManager(new EfEventDal());
        Context c = new Context();



        public ActionResult Index()
        {
            tm.TicketDate(); // Süresi Geçen Bileti Kontrol Eden Metot
            return View();
        }

        [HttpGet]
        public ActionResult BuyTicket(int id)
        {
            var ticket = c.Events.FirstOrDefault(x=>x.EventId==id);
            return View(ticket);
        }

        [HttpPost]
        public ActionResult BuyTicket(Ticket p)
        {
            string username = (string)Session["UserName"];
            int userIdInfo = c.Users.Where(x => x.UserName == username).Select(y => y.UserID).FirstOrDefault();


            tm.TicketAdd(p, userIdInfo);
            return RedirectToAction("YourTicket");

        }

        public ActionResult YourTicket(Ticket p) 
        {
            int id = p.TicketId;

            var ticketValue = tm.GetByID(id);
            return View(ticketValue);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult CheckTicket()
        {   
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult CheckTicket(Ticket t)
        {

            if (tm.CheckTicket(t))
            {
                ViewBag.CheckTicket = "Biletiniz Geçerlidir.";
            }
            else
            {
                ViewBag.CheckTicket = "Geçersiz Bilet";
            }

            return View();
        }

    }
}