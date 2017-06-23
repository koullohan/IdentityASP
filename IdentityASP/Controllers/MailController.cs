using Business;
using Entities.VM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP.Controllers
{
    public class MailController : Controller
    {

        private static bool result = false;


        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMail(MailViewModel mail) 
        {

            if (ModelState.IsValid)
            {
                result = MailBusiness.SendMail(mail);
                if (result)
                {
                    ViewBag.Message = "File sent successfully";
                }
                else
                {
                    ViewBag.Message = "File not sent successfully";
                }
            }

            return PartialView("_Mail");

        }
    }
}