using ImagineSoftwareWebsite.HttpLifecycle;
using Microsoft.AspNetCore.Mvc;

namespace ImagineSoftwareWebsite.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class ApplicationsController : Controller
    {
        [Route(template: "projects-apps", Name = Definitions.APPLICATIONS_PAGE_CONTROLLER_NAME)]
        public IActionResult Index()
            => View();

        [Route(template: "projects-apps/invoice-maker-quick-easy", Name = "Invoice Maker - Quick & Easy")]
        public IActionResult InvoiceMaker()
            => View();

        [Route(template: "projects-apps/spandigest", Name = "SpandiGest - Software di gestione spandimenti agricoli")]
        public IActionResult SpandiGest()
            => View();
    }
}
