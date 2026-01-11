using okna24h.Data.Data.CMS;
using okna24h.Data.Data.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Users
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public DateTime? HireDate { get; set; } 
        public bool IsActive { get; set; } = true;
        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        // relacje
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Media> Medias { get; set; } = new List<Media>();
        public ICollection<Invoice> Invoice { get; } = new List<Invoice>();
        public ICollection<Order> Orders { get; } = new List<Order>();
        public ICollection<Return> Returns { get; } = new List<Return>();


    }
}
