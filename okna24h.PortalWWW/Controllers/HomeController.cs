using Microsoft.AspNetCore.Mvc;
using okna24h.Interfaces.CMS;
using okna24h.PortalWWW.Models;
using System.Diagnostics;

namespace okna24h.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly INewsService _newsService;
        private readonly IBannersService _bannersService;
        private readonly IWebsiteService _websiteService;

        public HomeController(ILogger<HomeController> logger, INewsService newsService, IBannersService bannersService, IWebsiteService websiteService)
        {
            _logger = logger;

            _newsService = newsService;
            _bannersService = bannersService;
            _websiteService = websiteService;
        }

        public async Task<IActionResult> Index(int? id)
        {

            ViewBag.NewsModel = await _newsService.GetNewsByItemTake(3);
            if (id == null)
                id = 1;
            var item = await _websiteService.FindWebsite(id.Value);
            return View(item);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
