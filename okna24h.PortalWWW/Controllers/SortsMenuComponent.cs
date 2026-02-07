using Microsoft.AspNetCore.Mvc;
using okna24h.Interfaces.Shop;

namespace okna24h.PortalWWW.Controllers
{
    public class SortsMenuComponent : ViewComponent
    {
     
        private readonly ISortsService _sortsService;
        public SortsMenuComponent(ISortsService sortsService)
        {
            _sortsService = sortsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await _sortsService.GetSorts();
            return View("SortsMenuComponent",item);
        }
    }
}
