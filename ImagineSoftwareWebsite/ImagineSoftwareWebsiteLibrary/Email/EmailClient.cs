using ImagineSoftwareWebsiteLibrary;
using ImagineSoftwareWebsiteLibrary.Logs;
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
        private readonly IMyLogger _logger;
        private readonly Configuration _configuration;
        private const string _subject = "Imagine Software - Nuovo contatto";

        public EmailClient(Configuration configuration, IMyLogger logger)
        {
            if (string.IsNullOrWhiteSpace(configuration.EmailHost)
                || string.IsNullOrWhiteSpace(configuration.EmailPassword)
                || string.IsNullOrWhiteSpace(configuration.EmailToAddress)
                || string.IsNullOrWhiteSpace(configuration.EmailUsername)
                || string.IsNullOrWhiteSpace(configuration.EmailToAddress)
                || string.IsNullOrWhiteSpace(configuration.EmailFromAddress)
                || string.IsNullOrWhiteSpace(configuration.EmailSupport))
            {
                throw new Exception("Misconfigured email client");
            }

            _logger = logger;
            _configuration = configuration;

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

        public async Task SendToNoreplyAddress(string message)
        {
            message = message.Replace("\n", "<br />");
            message += $"<br /><br />" +
                $"Eventuali risposte a questa email non saranno gestite. " +
                $"Per assistenza o per informazioni scrivi a {_configuration.EmailSupport}";

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration.EmailFromAddress),
                Subject = _subject,
                IsBodyHtml = true,
                Body = message
            };

            mailMessage.To.Add(_configuration.EmailToAddress);
            await _logger.Log($"Going to send an email: {message}");
            await _client.SendMailAsync(mailMessage);
        }
    }
}
