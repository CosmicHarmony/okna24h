using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using okna24h.Data.Data;
using okna24h.Interfaces.CMS;

namespace Okna24h.PortalWWW.Controllers
{
    public class NewsController : Controller
    {
        
        private readonly INewsService _newsService;
        private readonly IBannersService _bannersService;

        public NewsController(INewsService newsService, IBannersService bannersService)
        {
           
            _newsService = newsService;
            _bannersService = bannersService;
        }


        public async Task<IActionResult> Index(int id)
        {
           
            ViewBag.NewsModel = await _newsService.GetNewsByItemTake(3);
            var item = await _newsService.GetNews(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
    }
}
