using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using okna24h.Data.Data;
using okna24h.Data.Data.Shop;
using okna24h.Interfaces.CMS;
using okna24h.Interfaces.Shop;

namespace okna24h.PortalWWW.Controllers
{
    public class ShopController : Controller
    {
        private readonly Okna24hContext _context;
        private readonly IArticlesService _articleService;
        private readonly ISortsService _sortsService;
        private readonly IBannersService _bannersService;
        public ShopController(Okna24hContext context, ISortsService sortsService, IArticlesService articlesService, IBannersService bannersService)
        {
            _context = context; _sortsService = sortsService; _articleService = articlesService; _bannersService = bannersService;
        }
        public async Task<IActionResult> Index(int? id)
        {
           
            ViewBag.Sorts = await _sortsService.GetSorts();
            if (id == null)
            {
                id = 1;
            }
           
            var items = await _articleService.GetArticlesBySortId(id.Value); //dodaje value 
            return View(items);
        }
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Sorts = await _sortsService.GetSorts();

            return View(await _articleService.GetArticle(id));
        }
        public async Task<IActionResult> BestOffer()
        {
            var items = await _articleService.GetArticlesBestOffer();
            return View(items);
        }

      

        
       
        

    }
}