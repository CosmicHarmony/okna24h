using okna24h.Data.Data.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Orders
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;
        public decimal FinalPrice { get; set; }
        public string? Notes { get; set; }
        // Połączenie z artykułem (szablonem)
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        // Relacja do pozycji zamówienia
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
