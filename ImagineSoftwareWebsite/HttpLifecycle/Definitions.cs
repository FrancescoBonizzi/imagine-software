using System;

namespace ImagineSoftwareWebsite.HttpLifecycle
{
    public static class Definitions
    {
        [Obsolete("TODO: sistemare quando si passa al multilingua tramite routing")]
        public const string CURRENT_LOCALIZATION_CODE = "it-IT";

        public const string PARTITA_IVA = "02982280345";
        public const string JOB_TITLE = "Full stack .NET developer and App developer";
        public const string Email = "f.bonizzi@imaginesoftware.it";

#warning TODO Tradurre le voci nel menù!

        public const string JSON_LD_ORGANIZATION_DETAILS = 
            "\"name\": \"Imagine Software\", " +
            "\"legalName\": \"Imagine Software di Bonizzi Francesco\", " +
            "\"url\": \"https://www.imaginesoftware.it\", " +
            "\"logo\": \"https://www.imaginesoftware.it/images/logos/logo-imagine-software.jpg\", " +
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

        public const string JSON_LD_ORGANIZATION = 
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

        public const string JSON_LD_AUTHOR = $"\"author\": {JSON_LD_ORGANIZATION}";
    }
}
