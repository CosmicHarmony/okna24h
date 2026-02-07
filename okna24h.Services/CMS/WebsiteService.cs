using Microsoft.EntityFrameworkCore;
using okna24h.Data.Data;
using okna24h.Data.Data.CMS;
using okna24h.Interfaces.CMS;
using okna24h.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okna24h.Services.CMS
{
    public class WebsiteService :BaseService, IWebsiteService
    {
        public WebsiteService(Okna24hContext context) : base(context) { }

        public async Task<Website?> FindWebsite(int websiteId)
        {
            if (websiteId == null)
                websiteId = 1;
            var website = await _context.Websites.FindAsync(websiteId);
            return website;
        }

        public async Task<IList<Website>> GetWebsitesOrderBy()
        {
            var websites = await _context.Websites.OrderBy(w => w.Item).ToListAsync();
            return websites;
        }
    }
}
