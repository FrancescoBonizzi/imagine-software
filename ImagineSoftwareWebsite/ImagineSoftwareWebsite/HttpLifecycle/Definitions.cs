namespace ImagineSoftwareWebsite.HttpLifecycle
{
    public static class Definitions
    {
        public const string PARTITA_IVA = "02982280345";
        public const string JOB_TITLE = "Full stack .NET developer and Android developer";

        // Forse è troppo lungo? -> Usare un nome corto tipo info@imaginesoftware.it o fb@imaginesoftware.it
#warning Impostare email
        public const string Email = "francesco.bonizzi@imaginesoftware.it";

        public const string CONTROLLER_API_ROUTE_NAME = "api";

        public const string HOME_PAGE_CONTROLLER_NAME = "Home";
        public const string CONTACT_PAGE_CONTROLLER_NAME = "Contatti";
        public const string SERVICES_PAGE_CONTROLLER_NAME = "L'offerta di Imagine Software";
        public const string FRANCESCO_PAGE_CONTROLLER_NAME = "Francesco Bonizzi";
        public const string PRIVACY_PAGE_CONTROLLER_NAME = "Informativa sulla privacy";
        public const string SITEMAP_PAGE_CONTROLLER_NAME = "Mappa del sito";
        public const string OPEN_SOURCE_PROJECTS_PAGE_CONTROLLER_NAME = "Progetti open source";
        public const string APPLICATIONS_PAGE_CONTROLLER_NAME = "Applicazioni";

        public static string JSON_LD_ORGANIZATION_DETAILS = 
            "\"name\": \"Imagine Software\", " +
            "\"legalName\": \"Imagine Software di Bonizzi Francesco\", " +
            "\"url\": \"https://www.imaginesoftware.it\", " +
            $"\"vatID\": \"{PARTITA_IVA}\"," +
            "\"location\": \"Italy\"," +
            "\"sameAs\": [" +
                "\"https://www.imaginesoftware.it\"" +
            "]," +
            "\"foundingDate\": \"2021\"," +
            "\"founders\": [ " +
                "{" +
                "\"@type\": \"Person\"," +
                "\"name\": \"Francesco Bonizzi\"" +
                "}" +
            "]," +
            "\"contactPoint\": {" +
                "\"@type\": \"ContactPoint\"," +
                "\"contactType\": \"customer support\"," +
                $"\"email\": \"{Email}\"" +
           " }";

        public static string JSON_LD_ORGANIZATION = 
            "{ " +
                "\"@type\": \"Organization\", " +
                JSON_LD_ORGANIZATION_DETAILS +
            "}";

        public const string JSON_LD_FREE_APP = 
            "\"offers\":[" +
                "{" +
                    "\"@type\":\"Offer\"," +
                    "\"price\":\"0\"," +
                    "\"priceCurrency\":\"XXX\"," +
                    "\"availability\":\"https://schema.org/InStock\"" +
            "}]";

        public static string JSON_LD_AUTHOR = $"\"author\": {JSON_LD_ORGANIZATION}";
    }
}
