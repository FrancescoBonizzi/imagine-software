using Microsoft.AspNetCore.Mvc;

namespace ImagineSoftwareWebsite.Controllers
{
    public class CustomersController : Controller
    {
        [Route(template: "clienti-casestudy", Name = "Clienti e case study")]
        public IActionResult Index()
            => View();

        [Route(template: "invoice-maker-quick-easy", Name = "Invoice Maker - Quick & Easy")]
        public IActionResult InvoiceMaker()
            => View();

        [Route(template: "rellow-game", Name = "Rellow")]
        public IActionResult Rellow()
            => View();

        [Route(template: "aragest", Name = "ARAGest - Software di gestione agricola")]
        public IActionResult ARAGest()
            => View();
    }
}
