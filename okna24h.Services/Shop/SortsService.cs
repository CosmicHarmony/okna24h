using Microsoft.EntityFrameworkCore;
using okna24h.Data.Data;
using okna24h.Data.Data.Shop;
using okna24h.Interfaces.Shop;
using okna24h.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okna24h.Services.Shop
{
    public class SortsService: BaseService, ISortsService
    {
        public SortsService(Okna24hContext context) : base(context)
        {
        }
        public async Task<IList<Sort>> GetSorts()
        {
            var sorts = await _context.Sorts.ToListAsync();
            return sorts;
        }
    }
}

