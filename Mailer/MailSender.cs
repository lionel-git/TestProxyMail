using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Web;

namespace Mailer
{
    public class MailSender : IDisposable
    {
        private SmtpClient _smtpClient;

        public MailSender(string hostname)
        {
            _smtpClient = new SmtpClient(hostname);
        }

        public static string TextToHtml(string text)
        {
            text = HttpUtility.HtmlEncode(text);
            text = text.Replace("\r\n", "\r");
            text = text.Replace("\n", "\r");
            text = text.Replace("\r", "<br>\r\n");
            text = text.Replace("  ", " &nbsp;");
            return text;
        }

        public void Send(string to, string subject, string body, params string[] fileNames)
        {
            var toAddress = new MailAddress(to);
            var fromAddress = new MailAddress("lionel.desorme@free.fr", "Test SmtpSender");
            var message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            //objMM.Body = "<span style=""font-family:Arial;font-size: 10pt;"">Dear &nbsp" & txtName.Text &"</span>"
            message.Body = $"<span style=\"font-family:Courier New;font-size: 10pt;\">{TextToHtml(body)}</span>";
            message.IsBodyHtml = true;
            foreach (var fileName in fileNames)
            {
                message.Attachments.Add(new Attachment(fileName));
            }            
            _smtpClient.Send(message);
        }

        public void Dispose()
        {
            _smtpClient.Dispose();
        }
    }
}
