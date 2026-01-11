using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Orders
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int OrderItemNo { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal BasePricePerUnit { get; set; }

        public double TaxRate { get; set; }

        public double Quantity { get; set; }

        public double Discount { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        [ForeignKey("OrderId")]

        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        [ForeignKey("Tax")]
        public int TaxId { get; set; }
        public Tax? Tax { get; set; }
        public InvoiceItem? InvoiceItem { get; set; }
        public ReturnItem? ReturnItem { get; set; }
        public ShipmentItem? ShipmentItem { get; set; }
        [NotMapped]
        public decimal NetAmount => BasePricePerUnit * (decimal)Quantity * (1 - (decimal)Discount);

        [NotMapped]
        public decimal TaxAmount => NetAmount * (Tax?.Rate ?? (decimal)TaxRate);

        [NotMapped]
        public decimal GrossAmount => NetAmount + TaxAmount;

    }
}
