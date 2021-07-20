namespace ImagineSoftwareWebsiteLibrary
{
    /// <summary>
    /// Un oggetto di configurazione per tutto il sito
    /// </summary>
    public class Configuration
    {
        public string EmailHost { get; } = "smtp.ionos.it";
        public int EmailHostPort { get; } = 465;
        public string EmailUsername { get; } = "noreply@imaginesoftware.it";
        public string EmailPassword { get; } = "t@3iMziNDzyJReZ2t&ty";
        public string EmailToAddress { get; } = "f.bonizzi@imaginesoftware.it";
        public string EmailFromAddress { get; } = "noreply@imaginesoftware.it";
    }
}
