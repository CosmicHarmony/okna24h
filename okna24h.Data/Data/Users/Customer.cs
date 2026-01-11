using okna24h.Data.Data.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Users
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public required string PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;
        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        // Navigation properties can be added here if needed
        // public ICollection<Order> Orders { get; set; } = new List<Order>();
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; } = string.Empty;
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Return> Returns { get; set; } = new List<Return>();


    }
}
