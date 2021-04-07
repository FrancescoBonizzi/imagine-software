using ImagineSoftwareWebsite.Email;
using ImagineSoftwareWebsite.Models.API;
using ImagineSoftwareWebsiteLibrary.Email;
using ImagineSoftwareWebsiteLibrary.Extensions;
using ImagineSoftwareWebsiteLibrary.Logs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ImagineSoftwareWebsite.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly EmailClient _emailClient;
        private readonly IMyLogger _logger;

        public ApiController(EmailClient emailClient, IMyLogger logger)
        {
            _emailClient = emailClient;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/send-contact-message")]
        public async Task<IActionResult> SendContactMessage([FromBody] SendContactMessageRequest sendContactMessageRequest)
        {
            if (string.IsNullOrWhiteSpace(sendContactMessageRequest.Email))
                throw new Exception("Inserisci per favore il tuo indirizzo email, così che possa risponderti!");

            if (string.IsNullOrWhiteSpace(sendContactMessageRequest.Message))
                throw new Exception("Inserisci per favore un messaggio, altrimenti non a cosa rispondere!");

            if (string.IsNullOrWhiteSpace(sendContactMessageRequest.Name))
                throw new Exception("Inserisci per favore il tuo nome");

            if (!sendContactMessageRequest.PrivacyAccepted)
                throw new Exception("Non posso inviare il messaggio se non accetti l'informativa sulla privacy. Grazie!");


            string today = DateTimeOffset.Now.ToItalianTimestampString();
            string message = $"Richiesta da {sendContactMessageRequest.Name} ({sendContactMessageRequest.Email}) " +
               $"in data {today} " +
               $"<br /><br />";

            try
            {
                if (EmailValidity.IsValidEmail(sendContactMessageRequest.Email))
                    throw new Exception("C'è qualcosa che non quadra nell'indirizzo email che hai inserito!");

                await _emailClient.Send(message);
            }
            catch (Exception ex)
            {
                // Non voglio perdermi potenziali email corrette per bug nella validazione, quindi loggo tutto
                await _logger.Log($"Errore nell'invio email: {message}" + Environment.NewLine + Environment.NewLine + ex.ToString());
            }

            return Ok();
        }
    }
}
