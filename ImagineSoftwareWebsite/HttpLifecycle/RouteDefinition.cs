using System;

namespace ImagineSoftwareWebsite.HttpLifecycle
{
    public class RouteDefinition
    {
        public string Section { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public bool IsIndexPage { get; set; }
    }
}
