using System;
using System.Text;
using System.Net;
using System.Web;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Net.Mail;
using System.IO;



namespace MoreAll
{
    public class MailUtilities
    {
        //public static void SendMail(string sendername, string email, string password, string to, string host, int port, string title, string body)
        //{
        //    SmtpClient m = new SmtpClient("" + host + "", port);
        //    System.Net.Mail.MailMessage mailc = new System.Net.Mail.MailMessage(email, to, title, body);
        //    mailc.IsBodyHtml = true;
        //    m.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    m.EnableSsl = true;
        //    m.UseDefaultCredentials = false;
        //    m.Credentials = new NetworkCredential(email, password);
        //    m.Send(mailc);
        //}
        //public static void SendMail(string sendername, string email, string password, string to, string host, int port, string title, string body)
        //{
        //    MailMessage message = new MailMessage();
        //    MailAddress address = new MailAddress(email, sendername);
        //    message.From = address;
        //    MailAddress item = new MailAddress(to);
        //    message.To.Add(item);
        //    message.Subject = title;
        //    message.Body = body;
        //    message.BodyEncoding = Encoding.UTF8;
        //    message.IsBodyHtml = true;
        //    SmtpClient client = new SmtpClient();
        //    NetworkCredential credential = new NetworkCredential();
        //    credential.UserName = email;
        //    credential.Password = password;
        //    client.Credentials = credential;
        //    client.Host = host;
        //    client.Port = port;
        //    client.Send(message);
        //}
        
        public static void SendMail(string sendername, string email, string password, string to, string host, int port, string title, string body)
        {
            MailMessage message = new MailMessage();
            MailAddress address = new MailAddress(email, sendername);
            message.From = address;
            MailAddress item = new MailAddress(to);
            message.To.Add(item);
            message.Subject = title;
            message.Body = body;
            message.Priority = MailPriority.Normal;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            NetworkCredential credential = new NetworkCredential();
            credential.UserName = email;
            credential.Password = password;
            client.Credentials = credential;
            client.EnableSsl = true;
            client.Host = host;
            client.Port = port;
            client.Send(message);
        }
       
        public static void SendMail2(string sendername, string email, string password, string[] to, string host, int port, string title, string body)
        {
            MailMessage message = new MailMessage();
            MailAddress address = new MailAddress(email, sendername);
            message.From = address;
            for (int i = 0; i < to.Length; i++)
            {
                if ((to[i].Trim().Length > 0) && ValidateUtilities.IsValidEmail(to[i]))
                {
                    MailAddress item = new MailAddress(to[i]);
                    message.To.Add(item);
                }
            }
            message.Subject = title;
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            NetworkCredential credential = new NetworkCredential();
            credential.UserName = email;
            credential.Password = password;
            client.Credentials = credential;
            client.Host = host;
            client.Port = port;
            client.Send(message);
        }
    }
}






