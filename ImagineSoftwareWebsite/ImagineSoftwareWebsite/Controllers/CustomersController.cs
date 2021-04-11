using ImagineSoftwareWebsite.HttpLifecycle;
using Microsoft.AspNetCore.Mvc;

namespace ImagineSoftwareWebsite.Controllers
{
    public class CustomersController : Controller
    {
        [Route(template: "clienti-casestudy", Name = Definitions.CUSTOMERS_PAGE_CONTROLLER_NAME)]
        public IActionResult Index()
            => View();

        [Route(template: "clienti-casestudy/invoice-maker-quick-easy", Name = "Invoice Maker - Quick & Easy")]
        public IActionResult InvoiceMaker()
            => View();

        [Route(template: "clienti-casestudy/rellow-game", Name = "Rellow")]
        public IActionResult Rellow()
            => View();

        [Route(template: "clienti-casestudy/aragest", Name = "ARAGest - Software di gestione agricola")]
        public IActionResult ARAGest()
            => View();
    }
}
