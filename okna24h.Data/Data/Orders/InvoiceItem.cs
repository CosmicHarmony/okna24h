using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Orders
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BasePricePerUnit { get; set; }

        public double Quantity { get; set; }

        public double Discount { get; set; } = 0;

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        //FK OrderItem
        [ForeignKey("OrderItem")]
        public int OrderItemId { get; set; }
        public OrderItem? OrderItem { get; set; }

        // FK Invoice
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        // FK  Tax
        [ForeignKey("Tax")]
        public int TaxId { get; set; }
        public Tax? Tax { get; set; }

        // Obliczenia (nie mapowane)
        [NotMapped]
        public decimal NetTotal => BasePricePerUnit * (decimal)Quantity * (1 - (decimal)Discount);

        [NotMapped]
        public decimal TaxAmount => NetTotal * Tax.Rate;

        [NotMapped]
        public decimal GrossTotal => NetTotal + TaxAmount;
    }
}
