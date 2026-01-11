using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Orders
{
    public class Shipment
    {
        [Key]
        public int ShipmentId { get; set; }

        public string ShipmentCode { get; set; } = string.Empty; // np. SH2026-001

        public DateTime ShipmentDate { get; set; } = DateTime.Now;

        public string Carrier { get; set; } = string.Empty; // np. DHL, UPS

        public string TrackingNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        public ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();

    }
}
