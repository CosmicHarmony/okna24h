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
    public class Return
    {
        [Key]
        public int ReturnId { get; set; }

        public string ReturnCode { get; set; } = string.Empty; 
        public DateTime ReturnDate { get; set; } = DateTime.Now;

        public string Reason { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public bool IsProcessed { get; set; } = false;
        public DateTime? ProcessedDate { get; set; }
        public bool IsActive { get; set; } = true;
        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public ICollection<ReturnItem> ReturnItems { get; set; } = new List<ReturnItem>();

    }
}
