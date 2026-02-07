using Microsoft.Identity.Client;
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

namespace okna24h.Services.Shop
{
    public class ArticlesService : BaseService, IArticlesService
    {
        public ArticlesService(Okna24hContext context) : base(context) { }

        public async Task<Article?> GetArticle(int articleId)
        {
            var article = await _context.Articles.Where(a => a.ArticleId == articleId).FirstOrDefaultAsync();
                return article;
        }
        public async Task<IList<Article>> GetArticlesBySortId(int sortId)
        {
            var articles = await _context.Articles.Where(a => a.SortId == sortId).ToListAsync();
            return articles;
        }
        public async Task<IList<Article>> GetArticlesBestOffer()
        {
            var articles = await _context.Articles.Where(a => a.BestOffer == true).ToListAsync();
            return articles;
        }
    }
}
