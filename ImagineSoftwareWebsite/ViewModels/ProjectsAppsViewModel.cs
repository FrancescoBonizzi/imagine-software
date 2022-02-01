using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class ProjectsAppsSquidex : Content<ProjectsAppsViewModel> { }

    public class ProjectsAppsViewModel
    {
        public string CurrentLocalizationCode { get; set; }
        public string RouteName { get; set; }

        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Subtitle { get; set; }
        public Dictionary<string, string> MetaDescription { get; set; }
        public Dictionary<string, string> ShortDescription { get; set; }
        public Dictionary<string, string> LogoAlt { get; set; }

#warning sono brutti così, conviene pescare la culture direttamente dalla view
        public string LocalizedTitle => Title[CurrentLocalizationCode];
        public string LocalizedSubtitle => Subtitle[CurrentLocalizationCode];
        public string LocalizedMetaDescription => MetaDescription[CurrentLocalizationCode];
        public string LocalizedShortDescription => ShortDescription[CurrentLocalizationCode];
        public string LocalizedLogoAlt => LogoAlt[CurrentLocalizationCode];


        [JsonConverter(typeof(InvariantConverter))]
        public string JsonStructuredData { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string[] Logo { get; set; }

        public string LogoImageLink { get; set; }

        public Dictionary<string, DownloadButtonViewModel[]> DownloadButtons { get; set; }
        public Dictionary<string, SectionViewModel[]> Sections { get; set; }

    }
}
