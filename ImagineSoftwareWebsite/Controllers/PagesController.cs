﻿using ImagineSoftwareWebsite.HttpLifecycle;
using ImagineSoftwareWebsite.Models;
using ImagineSoftwareWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Squidex.ClientLibrary;
using System.Linq;
using System.Threading.Tasks;

namespace ImagineSoftwareWebsite.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class PagesController : Controller
    {
        private readonly SquidexClientManager _squidexClientManager;

        public PagesController(
            SquidexClientManager squidexClientManager)
        {
            _squidexClientManager = squidexClientManager;
        }

        [Route(template: "/")]
        public async Task<IActionResult> Index()
        {
            var cmsTechnologies = _squidexClientManager.CreateContentsClient<TechnologySquidex, TechnologyViewModel>("technologies");
            var cmsCustomers = _squidexClientManager.CreateContentsClient<CustomersSquidex, CustomersViewModel>("customers");
            var cmsOpenSourceProjects = _squidexClientManager.CreateContentsClient<OpenSourceProjectSquidex, OpenSourceProjectViewModel>("open-source-projects");
            var cmsHomePage = _squidexClientManager.CreateContentsClient<HomePageSquidex, HomePageViewModel>("homepage");
            var context = QueryContext.Default.WithLanguages(CustomMiddlewares.GetCurrentCultureCode(HttpContext));

#warning Questi vanno fatti in parallelo!
            var technologies = await cmsTechnologies.GetAsync(context: context);
            foreach (var technology in technologies.Items)
            {
                technology.Data.CurrentLocalizationCode = CustomMiddlewares.GetCurrentCultureCode(HttpContext);
                technology.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(technology.Data.Logo);
            }

            var customers = await cmsCustomers.GetAsync(context: context);
            foreach (var c in customers.Items)
            {
                c.Data.CurrentLocalizationCode = CustomMiddlewares.GetCurrentCultureCode(HttpContext);
                c.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(c.Data.Logo);
            }

            var openSourceProjects = await cmsOpenSourceProjects.GetAsync(context: context);
            foreach (var o in openSourceProjects.Items)
            {
                o.Data.CurrentLocalizationCode = CustomMiddlewares.GetCurrentCultureCode(HttpContext);
                o.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(o.Data.Logo);
                o.Data.RouteName = o.Id;
            }

            // Il GUID è fisso e generato casualmente alla prima creazione della pagina su Squidex
            var page = await cmsHomePage.GetAsync("3b05830b-380e-43f0-b963-58a6931f3cf1", context);
            page.Data.CurrentLocalizationCode = CustomMiddlewares.GetCurrentCultureCode(HttpContext);

            page.Data.Technologies = technologies.Items.Select(t => t.Data).OrderBy(t => t.Name);
            page.Data.Customers = customers.Items.Select(c => c.Data).OrderBy(t => t.Name);
            page.Data.OpenSourceProjects = openSourceProjects.Items.Select(c => c.Data).OrderBy(t => t.Title[CustomMiddlewares.GetCurrentCultureCode(HttpContext)]);

            return View(page.Data);
        }

        [Route(template: "contacts")]
        public async Task<IActionResult> Contacts()
        {
            var cms = _squidexClientManager.CreateContentsClient<CommonPageSquidex, CommonPageViewModel>("common-pages");

            var context = QueryContext.Default.WithLanguages(CustomMiddlewares.GetCurrentCultureCode(HttpContext));
            var page = await cms.GetAsync("contacts", context);
            page.Data.CurrentLocalizationCode = CustomMiddlewares.GetCurrentCultureCode(HttpContext);
            return View(page.Data);
        }

        [Route(template: "services")]
        public async Task<IActionResult> Services()
        {
            var cms = _squidexClientManager.CreateContentsClient<ServicesSquidex, ServicesViewModel>("services");
            var context = QueryContext.Default.WithLanguages(CustomMiddlewares.GetCurrentCultureCode(HttpContext));

            // Il GUID è fisso e generato casualmente alla prima creazione della pagina su Squidex
            var page = await cms.GetAsync("212927bc-279f-4da4-a6bf-3fbd0b44cad7", context);
            page.Data.CurrentLocalizationCode = CustomMiddlewares.GetCurrentCultureCode(HttpContext);
            return View(page.Data);
        }

        [Route(template: "{squidexPageId}")]
        public async Task<IActionResult> CommonPage(string squidexPageId)
        {
            var cms = _squidexClientManager.CreateContentsClient<CommonPageSquidex, CommonPageViewModel>("common-pages");
            var context = QueryContext.Default.WithLanguages(CustomMiddlewares.GetCurrentCultureCode(HttpContext));

            try
            {
                var page = await cms.GetAsync(squidexPageId, context);
                page.Data.CurrentLocalizationCode = CustomMiddlewares.GetCurrentCultureCode(HttpContext);
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
            var context = QueryContext.Default.WithLanguages(CustomMiddlewares.GetCurrentCultureCode(HttpContext));
            var page = await cms.GetAsync(squidexPageId, context);

            page.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(page.Data.Logo);
            page.Data.CurrentLocalizationCode = CustomMiddlewares.GetCurrentCultureCode(HttpContext);
            page.Data.RouteName = page.Id;

            return View(page.Data);
        }

        [Route(template: "open-source-projects")]
        public async Task<IActionResult> OpenSourceProjectsList()
        {
            var cms = _squidexClientManager.CreateContentsClient<OpenSourceProjectSquidex, OpenSourceProjectViewModel>("open-source-projects");
            var context = QueryContext.Default.WithLanguages(CustomMiddlewares.GetCurrentCultureCode(HttpContext));
            var openSourceProjects = await cms.GetAsync(context: context);

            foreach (var openSourceProject in openSourceProjects.Items)
            {
                openSourceProject.Data.CurrentLocalizationCode = CustomMiddlewares.GetCurrentCultureCode(HttpContext);
                openSourceProject.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(openSourceProject.Data.Logo);
                openSourceProject.Data.RouteName = openSourceProject.Id;
            }

            return View(new OpenSourceProjectsListViewModel(
                openSourceProjects: openSourceProjects.Items.Select(p => p.Data).OrderBy(p => p.Title[CustomMiddlewares.GetCurrentCultureCode(HttpContext)]),
                localizedTitle: "I miei progetti open source",
                localizedSubTitle: "Codice aperto alla collaborazione di tutti",
                localizedMetaDescription: "I progetti open source di Imagine Software, accessibili liberamente tramite GitHub: librerie, piccoli software, videogiochi."));
        }

        [Route(template: "projects-apps/{squidexPageId}")]
        public async Task<IActionResult> ProjectsApps(string squidexPageId)
        {
#warning Ma questi IContentsClient si possono registrare singleton? "Do not create new clients frequently"
            var cms = _squidexClientManager.CreateContentsClient<ProjectsAppsSquidex, ProjectsAppsViewModel>("projects-applications");
            var context = QueryContext.Default.WithLanguages(CustomMiddlewares.GetCurrentCultureCode(HttpContext));
            var page = await cms.GetAsync(squidexPageId, context);

            page.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(page.Data.Logo);
            page.Data.CurrentLocalizationCode = CustomMiddlewares.GetCurrentCultureCode(HttpContext);
            page.Data.RouteName = page.Id;

            return View(page.Data);
        }

        [Route(template: "projects-apps")]
        public async Task<IActionResult> ProjectsAppsList()
        {
            var cms = _squidexClientManager.CreateContentsClient<ProjectsAppsSquidex, ProjectsAppsViewModel>("projects-applications");
            var context = QueryContext.Default.WithLanguages(CustomMiddlewares.GetCurrentCultureCode(HttpContext));
            var projects = await cms.GetAsync(context: context);

            foreach (var project in projects.Items)
            {
                project.Data.CurrentLocalizationCode = CustomMiddlewares.GetCurrentCultureCode(HttpContext);
                project.Data.LogoImageLink = _squidexClientManager.GenerateImageUrl(project.Data.Logo);
                project.Data.RouteName = project.Id;
            }

            return View(new ProjectsAppsListViewModel(
                projectsApps: projects.Items.Select(p => p.Data).OrderBy(p => p.Title[CustomMiddlewares.GetCurrentCultureCode(HttpContext)]),
                localizedTitle: "Applicazioni",
                localizedSubTitle: "Imagine Software per il mondo enterprise",
                localizedMetaDescription: "I prodotti ed i progetti di Imagine Software per il mondo enterprise, realizzati con cura e attenzione maniacale per i dettagli."));
        }

        [Route("/error/{code}")]
        public IActionResult StatusCodeError(int code)
            => View(new StatusCodeErrorViewModel(errorCode: code));
    }
}
