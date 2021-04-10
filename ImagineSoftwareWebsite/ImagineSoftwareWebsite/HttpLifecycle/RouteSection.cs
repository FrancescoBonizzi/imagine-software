using System.Collections.Generic;

namespace ImagineSoftwareWebsite.HttpLifecycle
{
    public class RouteSection
    {
        public string Section { get; set; }
        public IEnumerable<RouteDefinition> Routes { get; set; }
    }
}
