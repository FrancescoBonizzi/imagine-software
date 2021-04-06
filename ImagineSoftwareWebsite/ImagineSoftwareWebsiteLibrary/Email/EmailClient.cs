using ImagineSoftwareWebsiteLibrary;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ImagineSoftwareWebsite.Email
{
    /// <summary>
    /// Un banalissimo client per inviare email a me stesso
    /// </summary>
    public class EmailClient
    {
        private readonly SmtpClient _client;

#warning Email from da configurare
        private const string _from = "TODO";
        private const string _subject = "Imagine Software - Nuovo contatto";
        private readonly string _toAddress;

        public EmailClient(Configuration configuration)
        {
            _toAddress = configuration.EmailToAddress;

            if (string.IsNullOrWhiteSpace(configuration.EmailHost)
                || string.IsNullOrWhiteSpace(configuration.EmailPassword)
                || string.IsNullOrWhiteSpace(configuration.EmailToAddress)
                || string.IsNullOrWhiteSpace(configuration.EmailUsername))
            {
                throw new Exception("Misconfigured email client");
            }
            _client = new SmtpClient
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = configuration.EmailHost,
                Port = configuration.EmailHostPort
            };

            _client.Credentials = new NetworkCredential(
                userName: configuration.EmailUsername,
                password: configuration.EmailPassword);
        }

        public async Task Send(string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_from),
                Subject = _subject,
                Body = message
            };

            mailMessage.To.Add(_toAddress);
            await _client.SendMailAsync(mailMessage);
        }
    }
}
