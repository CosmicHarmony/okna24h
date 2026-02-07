using Microsoft.AspNetCore.Mvc;
using okna24h.Interfaces.CMS;

namespace Okna24h.PortalWWW.Controllers
{
    public class BannersComponent : ViewComponent
    {
        private readonly IBannersService _bannersService;
        public BannersComponent(IBannersService bannersService)
        {
            _bannersService = bannersService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await _bannersService.GetBanner();
            return View("BannersComponent", item);
        }
    }
}
