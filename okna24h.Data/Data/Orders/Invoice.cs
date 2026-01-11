using okna24h.Data.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Orders
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [StringLength(30)]
        public string InvoiceCode { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime DateOfIssue { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime PaymentDate { get; set; }
        public decimal NetTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal GrossTotal => NetTotal + TaxTotal;

        public bool IsPaid { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        // Klient powiązany z fakturą
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        // Opcjonalnie: kto wystawił fakturę
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public ICollection<Payment> Payments { get; } = new List<Payment>();

        public ICollection<InvoiceItem> InvoiceItems { get; } = new List<InvoiceItem>();

    }
}
