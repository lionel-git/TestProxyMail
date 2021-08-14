using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace Mailer
{
    public class MailSender : IDisposable
    {
        private SmtpClient _smtpClient;

        public MailSender(string hostname)
        {
            _smtpClient = new SmtpClient(hostname);
        }

        public void Send(string to, string subject, string body, params string[] fileNames)
        {
            var toAddress = new MailAddress(to);
            var fromAddress = new MailAddress("lionel.desorme@free.fr", "Test SmtpSender");
            var message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = body;
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
