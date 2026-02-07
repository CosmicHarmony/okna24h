using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using okna24h.Data.Data;
using okna24h.Interfaces.CMS;

namespace Okna24h.PortalWWW.Controllers
{
    public class LinksComponent : ViewComponent
    {
        
        private readonly IWebsiteService _websiteService;
        public LinksComponent(IWebsiteService websiteService)
        {
            
            _websiteService = websiteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await _websiteService.GetWebsitesOrderBy();
            return View("LinksComponent",item);
        }
    }
}
