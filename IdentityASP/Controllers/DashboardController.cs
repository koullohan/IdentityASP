using IdentityASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP.Controllers
{

    [Authorize]
    public class DashboardController : Controller
    {       
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Create(string name)
        {
            return View();
        }



    }
}