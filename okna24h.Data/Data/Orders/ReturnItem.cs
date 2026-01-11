using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Orders
{
    public class ReturnItem
    {
        [Key]
        public int ReturnItemId { get; set; }
        public double Quantity { get; set; }
        public string? Reason { get; set; }

        public bool IsApproved { get; set; } = false;
        public bool IsActive { get; set; } = true;
        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        // Snapshot cen (opcjonalnie)
        public decimal UnitPrice { get; set; }
        [ForeignKey("Return")]
        public int ReturnId { get; set; }
        public Return Return { get; set; } = null!;
        [ForeignKey("OrderItem")]
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; } = null!;
    }

}

