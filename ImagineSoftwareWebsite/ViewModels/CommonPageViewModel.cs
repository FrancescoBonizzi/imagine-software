using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class CommonPageSquidex : Content<CommonPageViewModel> { }

    public class CommonPageViewModel
    {
        public string CurrentLocalizationCode { get; set; }

        public string LocalizedTitle => Title[CurrentLocalizationCode];
        public string LocalizedSubtitle => Subtitle[CurrentLocalizationCode];
        public string LocalizedMetaDescription => MetaDescription[CurrentLocalizationCode];
        public string LocalizedBody => Body[CurrentLocalizationCode];

        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Subtitle { get; set; }
        public Dictionary<string, string> MetaDescription { get; set; }
        public Dictionary<string, string> Body { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string JsonStructuredData { get; set; }
    }
}
