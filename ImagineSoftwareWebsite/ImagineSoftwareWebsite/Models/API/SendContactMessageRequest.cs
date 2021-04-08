namespace ImagineSoftwareWebsite.Models.API
{
    public class SendContactMessageRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool PrivacyAccepted { get; set; }

        /// <summary>
        /// Campo per honeypot
        /// https://stackoverflow.com/questions/36227376/better-honeypot-implementation-form-anti-spam
        /// </summary>
        public string Password { get; set; }
    }
}
