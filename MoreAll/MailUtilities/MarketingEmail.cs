using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MoreAll
{
    public class MarketingEmail
    {
        private static Random _random = new Random();

        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor((double)((26.0 * _random.NextDouble()) + 65.0)))));
            }
            return builder.ToString();
        }

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

        public static void SendMail(string sendername, string email, string password, string to, string cc, string bcc, string host, int port, string title, string body)
        {
            MailMessage message = new MailMessage();
            MailAddress address = new MailAddress(email, sendername);
            message.From = address;
            MailAddress item = new MailAddress(to);
            message.To.Add(item);
            if (!cc.Equals(""))
            {
                cc.Replace(";", ",");
                cc.Replace(" ", ",");
                message.CC.Add(cc);
            }
            if (!bcc.Equals(""))
            {
                bcc.Replace(";", ",");
                bcc.Replace(" ", ",");
                message.Bcc.Add(bcc);
            }
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

        public static void SendMail_with_BCC(string sendername, string email, string password, string to, string bcc, string host, int port, string title, string body)
        {
            MailMessage message = new MailMessage();
            MailAddress address = new MailAddress(email, sendername);
            message.From = address;
            MailAddress item = new MailAddress(to);
            message.To.Add(item);
            message.Bcc.Add(bcc);
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

        public delegate void SendMail_with_BCC_delegate(string sendername, string email, string password, string to, string bcc, string host, int port, string title, string body);

        public delegate void SendMail_No_BCC(string sendername, string email, string password, string to, string host, int port, string title, string body);
    }
}
