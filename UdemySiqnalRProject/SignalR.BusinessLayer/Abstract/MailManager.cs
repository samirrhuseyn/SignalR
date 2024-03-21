using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public class MailManager : IMailService
    {
        public void SendMail(string addMail, string body, string subject)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("eastsrestaurant@gmail.com");
            message.To.Add(new MailAddress(addMail));
            message.Subject = subject;
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = body;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("eastsrestaurant@gmail.com", "xzhczrchjhmxxybv");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}
