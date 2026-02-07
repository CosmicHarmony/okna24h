using okna24h.Data.Data.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Interfaces.Shop
{
    public interface IArticlesService
    {
        Task<Article?> GetArticle(int articleId);
        Task<IList<Article>> GetArticlesBySortId(int sortId);
        Task<IList<Article>> GetArticlesBestOffer();
    }
}
