using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Users
{
    public class PostCode
    {
        public int PostCodeId { get; set; }
        public required string Code { get; set; }
        
        public bool IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City? City { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
