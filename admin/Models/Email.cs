using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace admin.Models
{
    public static class Email
    {
        public static void SendCodeWithEmail(string mailaddress,int code)
        {
          MailAddress from = new MailAddress("tamerlaailn7@gmail.com", "<From Name>");
            MailAddress to = new MailAddress(mailaddress, "<To Name>");
            string subject = "Parol Dəyişmə";
            string body = $"Şifrəni dəyişmək üçün  - {code} -  code";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from.Address, "pqdlaecoezswsdxi")
            };
            using (var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body
            })
            
            smtp.Send(message);
        }  
    }
}