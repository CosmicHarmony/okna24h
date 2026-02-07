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
    public class NewsService : BaseService, INewsService
    {
        public NewsService(Okna24hContext context) : base(context) { }
        public async Task<IList<News>> GetNewsByItemTake(int HowManyGet)
        {
            var newses = await _context.News.OrderByDescending(n => n.Item).Take(HowManyGet).ToListAsync();
            return newses;
        }
        public async Task<News?> GetNews(int newsId)
        {
            var news = await _context.News.FirstOrDefaultAsync(n => n.NewsID == newsId);
            return news;

        }
    }
}
