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
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        
        [Required(ErrorMessage = "Code is required")]
        [MaxLength(30, ErrorMessage = "code max 30 ")]
        public required string OrderCode { get; set; } = string.Empty;
        [Column(TypeName = "datetime")]
        public DateTime DateOfIssue { get; set; }
        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
        

    }
}
