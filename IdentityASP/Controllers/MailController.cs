using Business;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityASP.Controllers
{
    public class MailController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddMail()
        {
            return View();
        }

        public ActionResult DeleteMail()
        {
            return View();
        }


        public ActionResult DraftMail()
        {
            return View();
        }


        public ActionResult SendMail(MailViewModel viewmodel)
        {
            
            var result = MailBusiness.SendMail(viewmodel);
            return View();
        }

        //public async Task<ActionResult> SendMail(MailViewModel viewmodel)
        //{

        //    var x =  MailDAO.SendMailAsync(viewmodel);
        //    var y = MailDAO.SendAnotherMailAsync(); 

        //    await Task.WhenAll(x,y);

        //    int resultA = x.Result;
        //    string resultB = y.Result;
        //    return View();
        //}

    }
}