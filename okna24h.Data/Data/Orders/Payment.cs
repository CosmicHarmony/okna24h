using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Orders
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } 

        public string? TransactionReference { get; set; } // np. nr przelewu

        public bool IsConfirmed { get; set; } = false;

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;
    }

}
