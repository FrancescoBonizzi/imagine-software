using ImagineSoftwareWebsite.HttpLifecycle;
using ImagineSoftwareWebsite.Models;
using ImagineSoftwareWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using Squidex.ClientLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagineSoftwareWebsite.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class PagesController : Controller
    {
        private readonly RoutesInspector _routesInspector;
        private readonly SquidexClientManager _squidexClientManager;

        public PagesController(
            RoutesInspector routesInspector,
            SquidexClientManager squidexClientManager)
        {
            _routesInspector = routesInspector;
            _squidexClientManager = squidexClientManager;
        }

        [Route(template: "/")]
        public async Task<IActionResult> Index()
        {
            var cmsTechnologies = _squidexClientManager.CreateContentsClient<TechnologySquidex, TechnologyViewModel>("technologies");
            var cmsCustomers = _squidexClientManager.CreateContentsClient<CustomersSquidex, CustomersViewModel>("customers");
            var context = QueryContext.Default.WithLanguages(Definitions.CURRENT_LOCALIZATION_CODE);

#warning Questi vanno fatti in parallelo!
            var technologies = await cmsTechnologies.GetAsync(context: context);

            foreach (var technology in technologies.Items)
            {
                technology.Data.CurrentLocalizationCode = Definitions.CURRENT_LOCALIZATION_CODE;
                technology.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(technology.Data.Logo);
            }

            var customers = await cmsCustomers.GetAsync(context: context);

            foreach (var c in customers.Items)
            {
                c.Data.CurrentLocalizationCode = Definitions.CURRENT_LOCALIZATION_CODE;
                c.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(c.Data.Logo);
            }

            return View(new IndexPageViewModel(
                technologies.Items.Select(t => t.Data),
                customers.Items.Select(c => c.Data)));
        }

        [Route(template: "contacts")]
        public async Task<IActionResult> Contacts()
        {
            var cms = _squidexClientManager.CreateContentsClient<CommonPageSquidex, CommonPageViewModel>("common-pages");

            var context = QueryContext.Default.WithLanguages(Definitions.CURRENT_LOCALIZATION_CODE);
            var page = await cms.GetAsync("contacts", context);
            page.Data.CurrentLocalizationCode = Definitions.CURRENT_LOCALIZATION_CODE;
            return View(page.Data);
        }

        [Route(template: "services")]
        public async Task<IActionResult> Services()
        {
            var cms = _squidexClientManager.CreateContentsClient<ServicesSquidex, ServicesViewModel>("services");
            var context = QueryContext.Default.WithLanguages(Definitions.CURRENT_LOCALIZATION_CODE);

            // Il GUID è fisso e generato casualmente alla prima creazione della pagina su Squidex
            var page = await cms.GetAsync("212927bc-279f-4da4-a6bf-3fbd0b44cad7", context);
            page.Data.CurrentLocalizationCode = Definitions.CURRENT_LOCALIZATION_CODE;
            return View(page.Data);
        }

        [Route(template: "{squidexPageId}")]
        public async Task<IActionResult> CommonPage(string squidexPageId)
        {
            var cms = _squidexClientManager.CreateContentsClient<CommonPageSquidex, CommonPageViewModel>("common-pages");
            var context = QueryContext.Default.WithLanguages(Definitions.CURRENT_LOCALIZATION_CODE);

            try
            {
                var page = await cms.GetAsync(squidexPageId, context);
                page.Data.CurrentLocalizationCode = Definitions.CURRENT_LOCALIZATION_CODE;
                return View(page.Data);
            }
            catch (SquidexException ex) when (ex.Message.Contains("does not exist"))
            {
                return NotFound();
            }
        }

        [Route(template: "open-source-projects/{squidexPageId}")]
        public async Task<IActionResult> OpenSourceProject(string squidexPageId)
        {
#warning Ma questi IContentsClient si possono registrare singleton? "Do not create new clients frequently"
            var cms = _squidexClientManager.CreateContentsClient<OpenSourceProjectSquidex, OpenSourceProjectViewModel>("open-source-projects");
            var context = QueryContext.Default.WithLanguages(Definitions.CURRENT_LOCALIZATION_CODE);
            var page = await cms.GetAsync(squidexPageId, context);

#warning Forse dovrei wrappare tutto questo con caching di 5 minuti?

            page.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(page.Data.Logo);
            page.Data.CurrentLocalizationCode = Definitions.CURRENT_LOCALIZATION_CODE;
            page.Data.RouteName = page.Id;

            return View(page.Data);
        }

        [Route(template: "open-source-projects")]
        public async Task<IActionResult> OpenSourceProjectsList()
        {
            var cms = _squidexClientManager.CreateContentsClient<OpenSourceProjectSquidex, OpenSourceProjectViewModel>("open-source-projects");
            var context = QueryContext.Default.WithLanguages(Definitions.CURRENT_LOCALIZATION_CODE);
            var openSourceProjects = await cms.GetAsync(context: context);

            foreach (var openSourceProject in openSourceProjects.Items)
            {
                openSourceProject.Data.CurrentLocalizationCode = Definitions.CURRENT_LOCALIZATION_CODE;
                openSourceProject.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(openSourceProject.Data.Logo);
                openSourceProject.Data.RouteName = openSourceProject.Id;
            }

#warning TODO scrivere in base al localization code
            return View(new OpenSourceProjectsListViewModel(
                openSourceProjects: openSourceProjects.Items.Select(p => p.Data),
                localizedTitle: "I miei progetti open source",
                localizedSubTitle: "Codice aperto alla collaborazione di tutti"));
        }

        [Route(template: "projects-apps/{squidexPageId}")]
        public async Task<IActionResult> ProjectsApps(string squidexPageId)
        {
#warning Ma questi IContentsClient si possono registrare singleton? "Do not create new clients frequently"
            var cms = _squidexClientManager.CreateContentsClient<ProjectsAppsSquidex, ProjectsAppsViewModel>("projects-applications");
            var context = QueryContext.Default.WithLanguages(Definitions.CURRENT_LOCALIZATION_CODE);
            var page = await cms.GetAsync(squidexPageId, context);

#warning Forse dovrei wrappare tutto questo con caching di 5 minuti?

            page.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(page.Data.Logo);
            page.Data.CurrentLocalizationCode = Definitions.CURRENT_LOCALIZATION_CODE;
            page.Data.RouteName = page.Id;

            return View(page.Data);
        }

        [Route(template: "projects-apps")]
        public async Task<IActionResult> ProjectsAppsList()
        {
            var cms = _squidexClientManager.CreateContentsClient<ProjectsAppsSquidex, ProjectsAppsViewModel>("projects-applications");
            var context = QueryContext.Default.WithLanguages(Definitions.CURRENT_LOCALIZATION_CODE);
            var projects = await cms.GetAsync(context: context);

            foreach (var project in projects.Items)
            {
                project.Data.CurrentLocalizationCode = Definitions.CURRENT_LOCALIZATION_CODE;
                project.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(project.Data.Logo);
                project.Data.RouteName = project.Id;
            }

#warning TODO scrivere in base al localization code
            return View(new ProjectsAppsListViewModel(
                projectsApps: projects.Items.Select(p => p.Data),
                localizedTitle: "Applicazioni",
                localizedSubTitle: "Imagine Software per il mondo enterprise"));
        }



        [Route(template: "sitemap")]
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
