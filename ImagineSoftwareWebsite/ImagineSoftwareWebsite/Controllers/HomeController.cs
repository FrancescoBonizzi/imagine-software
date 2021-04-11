using ImagineSoftwareWebsite.HttpLifecycle;
using ImagineSoftwareWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using System.Collections.Generic;

namespace ImagineSoftwareWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoutesInspector _routesInspector;

        public HomeController(RoutesInspector routesInspector)
        {
            _routesInspector = routesInspector;
        }

        [Route(template: "/", Name = Definitions.HOME_PAGE_CONTROLLER_NAME)]
        public IActionResult Index()
            => View();

        [Route(template: "contatti", Name = Definitions.CONTACT_PAGE_CONTROLLER_NAME)]
        public IActionResult Contacts()
            => View();

        [Route(template: "servizi-offerta", Name = Definitions.SERVICES_PAGE_CONTROLLER_NAME)]
        public IActionResult Services()
            => View();

        [Route(template: "francesco-bonizzi", Name = Definitions.FRANCESCO_PAGE_CONTROLLER_NAME)]
        public IActionResult Francesco()
            => View();

        [Route(template: "privacy", Name = Definitions.PRIVACY_PAGE_CONTROLLER_NAME)]
        public IActionResult Privacy()
            => View();

        [Route(template: "mappa-del-sito", Name = Definitions.SITEMAP_PAGE_CONTROLLER_NAME)]
        public IActionResult Sitemap()
            => View(new SitemapViewModel()
            {
                Routes = _routesInspector.AllRoutes
            });

        [Route(template: "sitemap.xml")]
        public IActionResult SitemapXml()
        {
            var routes = _routesInspector.AllRoutes;
            var nodes = new List<SitemapNode>();
            foreach (var section in routes)
            {
                foreach (var route in section.Value)
                {
                    nodes.Add(new SitemapNode(Url.Content(route.Url)));
                }
            }

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/error/{code}")]
        public IActionResult StatusCodeError(int code)
            => View(new StatusCodeErrorViewModel(errorCode: code));
    }
}
