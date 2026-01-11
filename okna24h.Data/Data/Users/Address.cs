using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Users
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Tipe street")]
        [MaxLength(50, ErrorMessage = "Street max. 50 ")]
        [Display(Name = "Street")]
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
        public string? FlatNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AdressDetails { get; set; }
        public string? AddressType { get; set; }
        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        [ForeignKey("PostCode")]
        public int PostCodeId { get; set; }
        public PostCode? PostCode { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; } 
        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; } 
    }
}
