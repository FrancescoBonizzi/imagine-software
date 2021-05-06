﻿using ImagineSoftwareWebsite.HttpLifecycle;
using Microsoft.AspNetCore.Mvc;

namespace ImagineSoftwareWebsite.Controllers
{
    public class PaidProjectsController : Controller
    {
        [Route(template: "projects-apps", Name = Definitions.PAID_PROJECTS_PAGE_CONTROLLER_NAME)]
        public IActionResult Index()
            => View();

        [Route(template: "projects-apps/invoice-maker-quick-easy", Name = "Invoice Maker - Quick & Easy")]
        public IActionResult InvoiceMaker()
            => View();

        [Route(template: "projects-apps/aragest", Name = "ARAGest - Software di gestione agricola")]
        public IActionResult ARAGest()
            => View();
    }
}
