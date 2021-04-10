using ImagineSoftwareWebsite.HttpLifecycle;
using System.Collections.Generic;

namespace ImagineSoftwareWebsite.Models
{
    public class SitemapViewModel
    {
        public IDictionary<string, IEnumerable<RouteDefinition>> Routes { get; set; }
    }
}
