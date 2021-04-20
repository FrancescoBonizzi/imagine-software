using ImagineSoftwareWebsite.HttpLifecycle;
using Microsoft.AspNetCore.Mvc;

namespace ImagineSoftwareWebsite.Controllers
{
    public class TinyProjectsController : Controller
    {
        [Route(template: "projects", Name = Definitions.TINY_PROJECTS_PAGE_CONTROLLER_NAME)]
        public IActionResult Index()
            => View();

        [Route(template: "projects/boolli", Name = "Boolli: interprete di espressioni booleane")]
        public IActionResult Boolli()
            => View();

        [Route(template: "projects/infart-game", Name = "INFART")]
        public IActionResult INFART()
            => View();

        [Route(template: "projects/restart-on-crash", Name = "Restart on crash")]
        public IActionResult RestartOnCrash()
            => View();

        [Route(template: "projects/smart-scale", Name = "Smart Scale 3000: vincitore iSolutions hackaton 2020")]
        public IActionResult SmartScale()
            => View();

        [Route(template: "projects/starfall-game", Name = "Starfall")]
        public IActionResult Starfall()
            => View();
    }
}
