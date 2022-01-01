using ImagineSoftwareWebsite.HttpLifecycle;
using ImagineSoftwareWebsite.Models;
using ImagineSoftwareWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using Squidex.ClientLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagineSoftwareWebsite.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class HomeController : Controller
    {
        private readonly RoutesInspector _routesInspector;
        private readonly SquidexClientManager _squidexClientManager;

        public HomeController(
            RoutesInspector routesInspector,
            SquidexClientManager squidexClientManager)
        {
            _routesInspector = routesInspector;
            _squidexClientManager = squidexClientManager;
        }

        [Route(template: "/", Name = Definitions.HOME_PAGE_CONTROLLER_NAME)]
        public IActionResult Index()
            => View();

        [Route(template: "contacts", Name = Definitions.CONTACT_PAGE_CONTROLLER_NAME)]
        public IActionResult Contacts()
            => View();

        [Route(template: "services", Name = Definitions.SERVICES_PAGE_CONTROLLER_NAME)]
        public IActionResult Services()
            => View();

        [Route(template: "francesco-bonizzi", Name = Definitions.FRANCESCO_PAGE_CONTROLLER_NAME)]
        public async Task<IActionResult> Francesco()
        {
            var cms = _squidexClientManager.CreateContentsClient<CommonPageSquidex, CommonPageViewModel>("common-pages");

            var context = QueryContext.Default.WithLanguages(Definitions.CURRENT_LOCALIZATION_CODE);
            var page = await cms.GetAsync("d2350924-54df-43c9-a009-df8c08a31899", context);
            page.Data.CurrentLocalizationCode = Definitions.CURRENT_LOCALIZATION_CODE;
            return View(page.Data);
        }

        [Route(template: "privacy-policy", Name = Definitions.PRIVACY_PAGE_CONTROLLER_NAME)]
        public IActionResult PrivacyPolicy()
            => View();

        [Route(template: "mission", Name = Definitions.MISSION_PAGE_CONTROLLER_NAME)]
        public IActionResult Mission()
            => View();

        [Route(template: "sitemap", Name = Definitions.SITEMAP_PAGE_CONTROLLER_NAME)]
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

        [Route("/error/{code}")]
        public IActionResult StatusCodeError(int code)
            => View(new StatusCodeErrorViewModel(errorCode: code));
    }
}
