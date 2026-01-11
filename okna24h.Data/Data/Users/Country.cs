using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Users
{
    public class Country
    {
        public int CountryId { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Code { get; set; } = string.Empty;
        public ICollection<Region> Regions { get; set; } = new List<Region>();
        
    }
}
