using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace ImagineSoftwareWebsite.HttpLifecycle
{
    public class RoutesInspector
    {
        private readonly IActionDescriptorCollectionProvider _routesProvider;

        public RoutesInspector(IActionDescriptorCollectionProvider provider)
        {
            _routesProvider = provider;
        }

        public List<RouteDefinition> GetAllRoutes()
        {
            return _routesProvider.ActionDescriptors.Items
                .Where(c => c.AttributeRouteInfo != null)
                .Select(c => new RouteDefinition()
                {
                    Url = c.AttributeRouteInfo.Template,
                    Name = c.AttributeRouteInfo.Name ?? "TODO"
                })
                .Where(r => !r.Url.Contains("api/") && !r.Url.Contains("error/"))
                .ToList();
        }
    }
}
