using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class HomePageSquidex : Content<HomePageViewModel> { }

    public class HomePageViewModel
    {
        public string CurrentLocalizationCode { get; set; }

        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Subtitle { get; set; }
        public Dictionary<string, string> MetaDescription { get; set; }
        public Dictionary<string, string> Box1 { get; set; }
        public Dictionary<string, string> Box2 { get; set; }
        public Dictionary<string, string> Box3 { get; set; }

        public Dictionary<string, string> ContactText { get; set; }
        public Dictionary<string, string> ContactCallToAction { get; set; }
        public Dictionary<string, string> TechnlogiesTitle { get; set; }
        public Dictionary<string, string> OpenSourceTitle { get; set; }
        public Dictionary<string, string> OpenSourceBody { get; set; }
        public Dictionary<string, string> OpenSourceCallToAction { get; set; }
        public Dictionary<string, string> CustomersTitle { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string JsonStructuredData { get; set; }

        public IEnumerable<TechnologyViewModel> Technologies { get; set; }
        public IEnumerable<CustomersViewModel> Customers { get; set; }
        public IEnumerable<OpenSourceProjectViewModel> OpenSourceProjects { get; set; }

        public Dictionary<string, HomepageSectionViewModel[]> HomepageSection { get; set; }

        public string GetSectionClassName(int currentSectionIndex) =>
            currentSectionIndex % 2 == 0
            ? "white-section"
            : "alt-section";
    }
}
