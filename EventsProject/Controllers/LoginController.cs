using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EventsProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UserLoginManager um = new UserLoginManager(new EfUserDal());

        EventManager em = new EventManager(new EfEventDal());


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminUserInfo = c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && 
                x.AdminPassword == p.AdminPassword);
            if(adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName,false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult AdminLogout()
        {
            FormsAuthentication.SignOut();
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult UserLogin() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(User p)
        {
            

            var userInfo = um.GetUser(p.UserName, p.Password);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
                Session["UserName"] = userInfo.UserName;
                return RedirectToAction("Index", "UserPanel");
            }
            else
            {
                ViewBag.LoginError = "Hatalı Kullanıcı Adı veya Şifre";
            }
            return View();

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("UserLogin");
        }
    }
}