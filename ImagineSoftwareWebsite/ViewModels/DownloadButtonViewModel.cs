using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace ImagineSoftwareWebsite.ViewModels
{
    public class DownloadButtonViewModel
    {
        public string IconName { get; set; }
        public string DownloadLink { get; set; }
        public string TextButton { get; set; }
        public string TextAlt { get; set; }
    }
}
