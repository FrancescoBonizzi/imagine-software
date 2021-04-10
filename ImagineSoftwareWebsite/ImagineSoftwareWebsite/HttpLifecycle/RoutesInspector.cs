using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
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

        // TODO: si potrebbe cachare
        public IDictionary<string, IEnumerable<RouteDefinition>> GetAllRoutes()
            => _routesProvider.ActionDescriptors.Items
                .Where(route => route.AttributeRouteInfo != null)
                .Select(route => new RouteDefinition()
                {
                    Section = route.RouteValues["controller"],
                    Url = route.AttributeRouteInfo.Template,
                    Name = route.AttributeRouteInfo.Name ?? "TODO",
                    IsIndexPage = route.RouteValues["action"].Equals("index", StringComparison.InvariantCultureIgnoreCase)
                })
                .Where(route =>
                    !route.Url.Contains("api/", StringComparison.InvariantCultureIgnoreCase)
                    && !route.Url.Contains("error/", StringComparison.InvariantCultureIgnoreCase))
                .GroupBy(route => route.Section)
                .OrderBy(route => route.Key)
                .Select(group => new
                {
                    Section = group.Key,
                    // True viene dopo a False
                    Routes = group.OrderByDescending(route => route.IsIndexPage).ThenBy(route => route.Name)
                })
                .ToDictionary(g => g.Section, g => g.Routes.AsEnumerable());
    }
}
