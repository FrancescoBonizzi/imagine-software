using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImagineSoftwareWebsite.HttpLifecycle
{
    /// <summary>
    /// Strumento di gestione delle routes del sito
    /// </summary>
    public class RoutesInspector
    {
        private readonly IActionDescriptorCollectionProvider _routesProvider;

        public RoutesInspector(IActionDescriptorCollectionProvider provider)
        {
            _routesProvider = provider;
        }

#warning Cachare singleton, basta metterlo nel costruttore e ciaone
        /// <summary>
        /// Ritorna tutte le route del sito escluse le API ed i file statici, 
        /// raggruppate per sezione (Controller)
        /// </summary>
        public IDictionary<string, IEnumerable<RouteDefinition>> GetAllRoutes()
        {
            var routes = new List<RouteDefinition>();

            foreach (var routeDescription in _routesProvider
                .ActionDescriptors
                .Items
                .Where(route => route.AttributeRouteInfo != null))
            {
                var routeDefinition = new RouteDefinition()
                {
                    Section = routeDescription.RouteValues["controller"],
                    Url = routeDescription.AttributeRouteInfo.Template,
                    Name = routeDescription.AttributeRouteInfo.Name ?? "TODO",
                    IsIndexPage = routeDescription.RouteValues["action"].Equals("index", StringComparison.InvariantCultureIgnoreCase)
                };

                // Fix per routing dell'HomePage, altrimenti viene messa a null nelle pagine di sitemap e non funziona come link!
                if (routeDescription.RouteValues["controller"] == "Home" && routeDefinition.IsIndexPage)
                {
                    routeDefinition.Url = "/";
                }

                // Queste pagine non le voglio indicizzare nella sitemap, non sono contenuti per gli utenti
                if (routeDefinition.Url.Contains("api/", StringComparison.InvariantCultureIgnoreCase)
                    || routeDefinition.Url.Contains("error/", StringComparison.InvariantCultureIgnoreCase)
                    || routeDefinition.Url.Contains("sitemap.xml", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                routes.Add(routeDefinition);
            }

            return routes
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
}
