using ImagineSoftwareWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
