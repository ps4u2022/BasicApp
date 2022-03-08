using System;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Web;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;

namespace BasicApp
{
    public class Connection
    {
        public string SendEmail(string to, string subject, string body, Attachment emailattachItem, string cc = "", string bcc = "")
        {
            string p = "";
            try
            {
                MailMessage mailMessage = new MailMessage();
                /// recepientEmail = ConfigurationManager.AppSettings["emailtosenddefault"];
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["emailuserName"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                if(emailattachItem!=null)mailMessage.Attachments.Add(emailattachItem);
                mailMessage.IsBodyHtml = true;
                 mailMessage.To.Add(to);
                if (cc != "") mailMessage.CC.Add(cc);
                if (bcc != "") mailMessage.Bcc.Add(bcc);
                SmtpClient smtp = new SmtpClient();
                p = "fl";
                smtp.Host = ConfigurationManager.AppSettings["emailhost"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["emailenableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["emailuserName"];
                NetworkCred.Password = ConfigurationManager.AppSettings["emailpassword"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["emailport"]);
                 p = "l";
                smtp.Send(mailMessage);
                p = "p";
                smtp.Dispose();
                return p;
            }
            catch (Exception ex)
            {
                return p+ ex.Message;
            }

        }
    }
}

