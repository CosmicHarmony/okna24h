using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Users
{
    public class City
    {
        public int CityId { get; set; }
        public required string Name { get; set; }
        
        public int RegionId { get; set; }
        public Region? Region { get; set; }
        public ICollection<PostCode> PostCodes { get; } = new List<PostCode>();
        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }

    }
}
