using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class DownloadButtonViewModel
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Logo { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string DownloadLink { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string TextButton { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string TextAlt { get; set; }
    }
}
