using ImagineSoftwareWebsite.Email;
using ImagineSoftwareWebsite.Models.API;
using ImagineSoftwareWebsiteLibrary.Email;
using ImagineSoftwareWebsiteLibrary.Extensions;
using ImagineSoftwareWebsiteLibrary.Logs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            // HoneyPot: se viene compilato questo campo hidden significa che è un bot, 
            // perché gli esseri umani non lo vedono
            if (!string.IsNullOrEmpty(sendContactMessageRequest.Password))
            {
                // Loggo comunque tutto, nel caso in cui ci sia stato un errore
                await _logger.Log("Spambot detected!" 
                    + Environment.NewLine 
                    + Environment.NewLine 
                    + JsonConvert.SerializeObject(sendContactMessageRequest));
                // Rispondo ok così il bot è contento
                return Ok();
            }

            if (string.IsNullOrWhiteSpace(sendContactMessageRequest.Email))
                return BadRequest("Inserisci per favore il tuo indirizzo email, così che possa risponderti!");

            if (string.IsNullOrWhiteSpace(sendContactMessageRequest.Message))
                return BadRequest("Inserisci per favore un messaggio, altrimenti non a cosa rispondere!");

            if (string.IsNullOrWhiteSpace(sendContactMessageRequest.Name))
                return BadRequest("Inserisci per favore il tuo nome");

            if (!sendContactMessageRequest.PrivacyAccepted)
                return BadRequest("Non posso inviare il messaggio se non accetti l'informativa sulla privacy. Grazie!");

            string today = DateTimeOffset.Now.ToItalianTimestampString();
            string message = $"Richiesta da {sendContactMessageRequest.Name} ({sendContactMessageRequest.Email}) " +
               $"in data {today} " +
               $"<br /><br />";

            if (!EmailValidity.IsValidEmail(sendContactMessageRequest.Email))
                return BadRequest("C'è qualcosa che non quadra nell'indirizzo email che hai inserito!");

            try
            {
                await _emailClient.Send(message);
            }
            catch (Exception ex)
            {
                // Non voglio perdermi potenziali email corrette per bug nella validazione, quindi loggo tutto
                await _logger.Log($"Errore nell'invio email: {message}" + Environment.NewLine + Environment.NewLine + ex.ToString());
                // Non ritorno errori perché tanto ho loggato tutto, quindi recupero il messaggio dai log
            }

            return Ok();
        }
    }
}
