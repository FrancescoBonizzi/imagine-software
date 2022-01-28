using ImagineSoftwareWebsite.HttpLifecycle;
using Microsoft.AspNetCore.Mvc;

namespace ImagineSoftwareWebsite.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class OpenSourceProjectsController : Controller
    {
        [Route(template: "open-source-projects", Name = Definitions.OPEN_SOURCE_PROJECTS_PAGE_CONTROLLER_NAME)]
        public IActionResult Index()
            => View();

    }
}
