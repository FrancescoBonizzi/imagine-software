namespace ImagineSoftwareWebsite.Models.API
{
    public class SendContactMessageRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool PrivacyAccepted { get; set; }
    }
}
