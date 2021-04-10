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

        [Route(template: "/", Name = "Home")]
        public IActionResult Index()
            => View();

        [Route(template: "contatti", Name = "Contatti")]
        public IActionResult Contacts()
            => View();

        [Route(template: "servizi-offerta", Name = "L'offerta di Imagine Software")]
        public IActionResult Services()
            => View();

        [Route(template: "francesco-bonizzi", Name = "Francesco Bonizzi")]
        public IActionResult Francesco()
            => View();

        [Route(template: "privacy", Name = "Privacy policy")]
        public IActionResult Privacy()
            => View();

        [Route(template: "sitemap", Name = "Mappa del sito")]
        public IActionResult Sitemap()
        {
            return View(new SitemapViewModel()
            {
                Routes = _routesInspector.GetAllRoutes()
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/error/{code}")]
        public IActionResult StatusCodeError(int code)
            => View(new StatusCodeErrorViewModel(errorCode: code));
    }
}
