namespace ImagineSoftwareWebsiteLibrary
{
    /// <summary>
    /// Un oggetto di configurazione per tutto il sito
    /// </summary>
    public class Configuration
    {
        public string EmailHost { get; }
        public int EmailHostPort { get; }
        public string EmailUsername { get; }
        public string EmailPassword { get; }
        public string EmailToAddress { get; }

        public Configuration()
        {
#warning Da configurare
            // TODO Valori
        }
    }
}
