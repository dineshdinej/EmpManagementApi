using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace EmpManagementApi.Common
{
    public class BAL
    {
        public static void SendMail(string To, string CC, string subject, string Mailbody)
        {
            MailMessage message = new MailMessage()
            {
                From = new MailAddress("Fromaddress.com", "HR Team"),
                Subject = subject,
                Body = Mailbody,
                IsBodyHtml = true
            };

            foreach (var address in To.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                message.To.Add(address);
            }
            foreach (var address in CC.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                message.Bcc.Add(address);
            }

            SmtpClient client = new SmtpClient("SenderPort");
            client.Send(message);
            client.Dispose();
        }

    }
}