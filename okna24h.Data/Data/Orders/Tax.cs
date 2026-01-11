using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Orders
{
    public class Tax
    {
        [Key]
        public int TaxId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? EditDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; } = new List<InvoiceItem>();
        public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
    }
}
