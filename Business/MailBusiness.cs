using Entities.VM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MailBusiness
    {

        private static bool result = false;


        public static bool SendMail(MailViewModel viewmodel)
        {

            try
            {
                SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                var message = new MailMessage();
                message.From = new MailAddress(section.From, viewmodel.MailName);
                message.To.Add(new MailAddress(section.Network.UserName));
                message.Subject = viewmodel.MailSubject;
                message.Body = viewmodel.MailBody;

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
            catch (Exception ex)
            {
                throw ex;
            }

            return result;

        }
    }
}
