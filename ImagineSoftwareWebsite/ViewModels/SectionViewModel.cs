using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class SectionViewModel
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Title { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Body { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public bool IsJustTitleSection { get; set; }
    }
}
