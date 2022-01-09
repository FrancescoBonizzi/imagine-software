using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class TechnologySquidex : Content<TechnologyViewModel> { }

    public class TechnologyViewModel
    {
        public string CurrentLocalizationCode { get; set; }

        public string LocalizedLinkTitle => LinkTitle[CurrentLocalizationCode];
        public string LocalizedLogoAlt => LogoAlt[CurrentLocalizationCode];

        [JsonConverter(typeof(InvariantConverter))]
        public string Name { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Link { get; set; }
        public Dictionary<string, string> LinkTitle { get; set; }
        public Dictionary<string, string> LogoAlt { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string[] Logo { get; set; }

        public string LogoImageLink { get; set; }
    }
}
