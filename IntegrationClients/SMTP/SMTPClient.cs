using IntegrationClients.SMTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClients
{
    public class SMTPClient
    {
        private string SMTPServerAddress;
        private NetworkCredential credentials;
        private string FromAddressDefault;

        public SMTPClient(string ServerAddress, NetworkCredential Credentials, string FromAddressDefault)
        {
            SMTPServerAddress = ServerAddress;
            credentials = Credentials;
            this.FromAddressDefault = FromAddressDefault;
        }

        private static object QuerySynchronizer = new object();
        public void TrySendEmail(EmailMessage message)
        {
            lock (QuerySynchronizer)
            {
                var mail = new MailMessage()
                {
                    From = new MailAddress(message.From ?? FromAddressDefault),
                    Subject = message.Subject,
                    Body = message.BodyWithHeaderAndFooter,
                    IsBodyHtml = message.HTML
                };

                mail.To.Add(message.To);
                if (message.ToCC != null)
                    mail.CC.Add(message.ToCC);
                if (message.ToBCC != null)
                    mail.Bcc.Add(message.ToBCC);

                using (var client = new SmtpClient()
                {
                    Host = SMTPServerAddress,
                    Credentials = credentials
                })
                    client.Send(mail);
            }
        }
    }
}