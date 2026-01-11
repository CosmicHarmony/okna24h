using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Users
{
    public class Region
    {
        public int RegionId { get; set; }
        public required string Name { get; set; }
        
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime? EditDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public ICollection<City> Cities { get; } = new List<City>();
    }
}
