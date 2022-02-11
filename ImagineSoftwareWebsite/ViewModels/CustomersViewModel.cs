using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class CustomersSquidex : Content<CustomersViewModel> { }

    public class CustomersViewModel
    {
        public string CurrentLocalizationCode { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Name { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Link { get; set; }
        public Dictionary<string, string> LinkTitle { get; set; }
        public Dictionary<string, string> LogoAlt { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string[] Logo { get; set; }

        public string LogoImageLink { get; set; }

        public Dictionary<string, string> JobDescription { get; set; }
    }
}
