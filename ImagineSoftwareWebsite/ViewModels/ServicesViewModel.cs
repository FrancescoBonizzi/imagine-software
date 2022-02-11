﻿using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class ServicesSquidex : Content<ServicesViewModel> { }

    public class ServicesViewModel
    {
        public string CurrentLocalizationCode { get; set; }

        public string LocalizedTitle => Title[CurrentLocalizationCode];
        public string LocalizedSubtitle => Subtitle[CurrentLocalizationCode];
        public string LocalizedMetaDescription => MetaDescription[CurrentLocalizationCode];

        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Subtitle { get; set; }
        public Dictionary<string, string> MetaDescription { get; set; }
        public Dictionary<string, SectionViewModel[]> Sections { get; set; }
    }
}