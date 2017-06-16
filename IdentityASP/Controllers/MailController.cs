using IdentityASP.Models.ViewModel;
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
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMail(MailViewModel mail) 
        {

            try
            {
                SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                var message = new MailMessage();
                message.From = new MailAddress(section.From, mail.MailName);
                message.To.Add(new MailAddress(section.Network.UserName));            
                message.Subject = mail.MailSubject;
                message.Body = mail.MailBody;

                using (var client = new SmtpClient())
                {                 
                    client.EnableSsl = section.Network.EnableSsl;
                    client.UseDefaultCredentials = section.Network.DefaultCredentials;
                    client.Credentials = new NetworkCredential(section.Network.UserName, section.Network.Password);
                    client.Host = section.Network.Host;
                    client.Port = section.Network.Port;                    
                    client.Send(message);
                    client.Dispose();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return PartialView("_Mail");

        }
    }
}