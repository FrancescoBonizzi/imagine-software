using Squidex.ClientLibrary;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class OpenSourceProjectSquidex : Content<OpenSourceProjectViewModel> { }

    public class OpenSourceProjectViewModel
    {
        public string CurrentLocalizationCode { get; set; }

        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Subtitle { get; set; }
        public Dictionary<string, string> MetaDescription { get; set; }
        public Dictionary<string, string> ShortDescription { get; set; }
        public Dictionary<string, string> LogoAlt { get; set; }
        public Dictionary<string, string> AnimatedGifAlt { get; set; }

        public string LocalizedTitle => Title[CurrentLocalizationCode];
        public string LocalizedSubtitle => Subtitle[CurrentLocalizationCode];
        public string LocalizedMetaDescription => MetaDescription[CurrentLocalizationCode];
        public string LocalizedShortDescription => ShortDescription[CurrentLocalizationCode];
        public string LocalizedLogoAlt => LogoAlt[CurrentLocalizationCode];
        public string LocalizedAnimatedGifAlt => AnimatedGifAlt[CurrentLocalizationCode];


        [JsonConverter(typeof(InvariantConverter))]
        public string JsonStructuredData { get; set; }


        [JsonConverter(typeof(InvariantConverter))]
        public string[] Logo { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string[] AnimatedGif { get; set; }

        public Dictionary<string, DownloadButtonViewModel[]> DownloadButtons { get; set; }
        public Dictionary<string, SectionViewModel[]> Sections { get; set; }

    }
}
