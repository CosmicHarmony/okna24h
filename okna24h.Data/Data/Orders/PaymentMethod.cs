using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Orders
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }

        [StringLength(128)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
