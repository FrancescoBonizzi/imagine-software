using ImagineSoftwareWebsite.HttpLifecycle;
using Microsoft.AspNetCore.Mvc;

namespace ImagineSoftwareWebsite.Controllers
{
    public class TinyProjectsController : Controller
    {
        [Route(template: "projects", Name = Definitions.TINY_PROJECTS_PAGE_CONTROLLER_NAME)]
        public IActionResult Index()
            => View();

        [Route(template: "booli", Name = "Booli: interprete di espressioni booleane")]
        public IActionResult Booli()
            => View();

        [Route(template: "infart-game", Name = "INFART")]
        public IActionResult INFART()
            => View();

        [Route(template: "restart-on-crash", Name = "Restart on crash")]
        public IActionResult RestartOnCrash()
            => View();

        [Route(template: "smart-scale", Name = "Smart Scale 3000: vincitore iSolutions hackaton 2020")]
        public IActionResult SmartScale()
            => View();

        [Route(template: "starfall-game", Name = "Starfall")]
        public IActionResult Starfall()
            => View();
    }
}
