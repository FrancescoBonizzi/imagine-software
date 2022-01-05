﻿using ImagineSoftwareWebsite.HttpLifecycle;
using Microsoft.AspNetCore.Mvc;

namespace ImagineSoftwareWebsite.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class OpenSourceProjectsController : Controller
    {
        [Route(template: "open-source-projects", Name = Definitions.OPEN_SOURCE_PROJECTS_PAGE_CONTROLLER_NAME)]
        public IActionResult Index()
            => View();

        [Route(template: "open-source-projects/boolli", Name = "Boolli: interprete di espressioni booleane")]
        public IActionResult Boolli()
            => View();

        [Route(template: "open-source-projects/infart-game", Name = "INFART")]
        public IActionResult INFART()
            => View();

        [Route(template: "open-source-projects/restart-on-crash", Name = "RestartOnCrash")]
        public IActionResult RestartOnCrash()
            => View();

        [Route(template: "open-source-projects/smart-scale-3000", Name = "Smart Scale 3000: la bilancia intelligente")]
        public IActionResult SmartScale3000()
            => View();

        [Route(template: "open-source-projects/starfall-game", Name = "Starfall")]
        public IActionResult Starfall()
            => View();

        [Route(template: "open-source-projects/rellow-game", Name = "Rellow")]
        public IActionResult Rellow()
            => View();
    }
}