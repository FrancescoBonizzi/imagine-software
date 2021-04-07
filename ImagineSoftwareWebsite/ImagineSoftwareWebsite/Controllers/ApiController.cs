using ImagineSoftwareWebsite.Email;
using ImagineSoftwareWebsite.Models.API;
using ImagineSoftwareWebsiteLibrary.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ImagineSoftwareWebsite.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly EmailClient _emailClient;

        public ApiController(EmailClient emailClient)
        {
            _emailClient = emailClient;
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
            await _emailClient.Send(
                message: $"Richiesta da {sendContactMessageRequest.Name} ({sendContactMessageRequest.Email}) " +
                $"in data {today} " +
                $"<br /><br />");

            return Ok();
        }
    }
}
