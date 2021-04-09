using ImagineSoftwareWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImagineSoftwareWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            => View();

        [Route("contatti")]
        public IActionResult Contacts()
            => View();

        [Route("clienti-casestudy")]
        public IActionResult Customers()
            => View();

        [Route("servizi-offerta")]
        public IActionResult Services()
            => View();

        [Route("francesco-bonizzi")]
        public IActionResult Francesco()
            => View();

        [Route("privacy")]
        public IActionResult Privacy()
            => View();

        [Route("sitemap")]
        public IActionResult Sitemap()
            => View();

        [Route("projects")]
        public IActionResult TinyProjects()
            => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/error/{code}")]
        public IActionResult StatusCodeError(int code)
            => View(new StatusCodeErrorViewModel(errorCode: code));
    }
}
