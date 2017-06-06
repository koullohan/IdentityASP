using IdentityASP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace IdentityASP.Business
{
    public class MailDAO
    {
        private static bool result = false;

        //public static async Task<int> SendMailAsync(MailViewModel viewmodel)
        //{
        //    HttpClient client = new HttpClient();
        //    Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");              
        //    string urlContents = await getStringTask;
        //    return urlContents.Length;
        //}

        //public static async Task<string> SendAnotherMailAsync()
        //{
        //    HttpClient client = new HttpClient();
        //    Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
        //    string urlContents = await getStringTask;
        //    return urlContents.FirstOrDefault().ToString();
        //}



        public static bool SendMail(MailViewModel viewmodel)
        {

            try
            {
                // You should use using block so .NET can clean up resources
                using (var client = new SmtpClient())
                {

                    MailMessage msg = new MailMessage();
                    //msg.From = new MailAddress(viewmodel.MailFrom);
                    foreach (var item in viewmodel.MailTo)
                    {
                        msg.To.Add(item);
                    }
                    msg.Body = viewmodel.MailBody;
                    msg.Subject = viewmodel.MailSubject;

                    client.Host = "smtp.gmail.com";
                    client.Port = 25;
                    client.Credentials = new NetworkCredential("koullohan@gmail.com", "#LocalMaster");
                    client.Send(msg);
                    //client.Dispose();

                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            
            }

            return result;

        }
    }
}