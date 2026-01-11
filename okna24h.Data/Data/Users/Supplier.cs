using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Users
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string NIP { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime? EditDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
        // relation
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
