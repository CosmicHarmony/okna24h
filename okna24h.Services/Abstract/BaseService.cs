using okna24h.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Services.Abstract
{
    public abstract class BaseService
    {
        protected readonly Okna24hContext _context;
        //protected readonly IServiceProvider serviceProvider;
        //protected readonly Lazy<IUzytkownikService> uzytkownik;
        //protected readonly Lazy<ICacheProvider> cacheProvider;
        //protected readonly Lazy<DapperProvider> dapperProvider;
        //protected readonly Lazy<IConfiguration> configuration;
        //protected readonly Lazy<IWyjatekObslugaService> wyjatekObslugaService;

        public BaseService(Okna24hContext context)
        {
            _context = context;
        }
    }

}
