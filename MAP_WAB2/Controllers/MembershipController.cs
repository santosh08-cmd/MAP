using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAP_WAB2.Models;
using System.Web.Security;

namespace MAP_WAB2.Controllers
{
    public class MembershipController : Controller
    {
        // GET: Membership
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            using (var contaxt = new officeEntities2())
            {
                bool isValid = contaxt.SignUps.Any(x => x.Username == model.Username && x.Paasword == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Username,false);
                    return RedirectToAction("Index", "Farmer");
                }
                ModelState.AddModelError("", "Invalid username and Password");           }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUp model)
        {
            using (var contaxt = new officeEntities2())
            {
                contaxt.SignUps.Add(model);
                contaxt.SaveChanges();
            }
            return RedirectToAction("login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}