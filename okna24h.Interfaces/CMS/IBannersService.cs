
using okna24h.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Interfaces.CMS
{
    public interface IBannersService
    {
        Task<Banner?> GetBanner();
    }
}
