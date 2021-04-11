using ImagineSoftwareWebsite.HttpLifecycle;
using ImagineSoftwareWebsite.Models;
using Microsoft.AspNetCore.Mvc;

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

        [Route(template: "sitemap", Name = Definitions.SITEMAP_PAGE_CONTROLLER_NAME)]
        public IActionResult Sitemap()
            => View(new SitemapViewModel()
            {
                Routes = _routesInspector.GetAllRoutes()
            });

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/error/{code}")]
        public IActionResult StatusCodeError(int code)
            => View(new StatusCodeErrorViewModel(errorCode: code));
    }
}
