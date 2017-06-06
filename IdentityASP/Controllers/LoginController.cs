using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return RedirectToAction("Register", "Account");
        }
    }
}