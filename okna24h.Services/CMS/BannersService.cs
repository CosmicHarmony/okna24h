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
    public class BannersService : BaseService, IBannersService
    {
        public BannersService(Okna24hContext context) : base(context)
        {
        }

        public async Task<Banner?> GetBanner()
        {
            var banner = await _context.Banners.FirstOrDefaultAsync();
            return banner;
        }
    }
}
