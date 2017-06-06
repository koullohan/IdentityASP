using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSales(Sales model)
        {
            var sales = SalesBusiness.GetSales(model.SalesYear);
            bool result = true;
            return Json(new { data = sales, success = result, JsonRequestBehavior.AllowGet });
        }

    }
}