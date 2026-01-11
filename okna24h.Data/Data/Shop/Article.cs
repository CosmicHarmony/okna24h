using okna24h.Data.Data.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Shop
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "code is required")]
        public required string Code { get; set; }

        [Required(ErrorMessage = "name is required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public required string FotoURL { get; set; }

        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }

        [ForeignKey("MaterialTypeColor")]
        public int MaterialTypeColorId { get; set; }
        public MaterialTypeColor? MaterialTypeColor { get; set; }
        [ForeignKey("Glass")]
        public int GlassId { get; set; }
        public Glass? Glass { get; set; }
        [ForeignKey("Sort")]
        public int SortId { get; set; }
        public Sort? Sort { get; set; }
        [ForeignKey("OpenningSystem")]
        public int OpenningSystemId { get; set; }
        public OpenningSystem? OpenningSystem { get; set; }
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public Profile? Profile { get; set; }
        [ForeignKey("Roller")]
        public int RollerId { get; set; }
        public Roller? Roller { get; set; }
        [ForeignKey("Sash")]
        public int SashId { get; set; }
        public Sash? Sash { get; set; }
        [ForeignKey("Shutter")]
        public int ShutterId { get; set; }
        public Shutter? Shutter { get; set; }
        [ForeignKey("Size")]
        public int SizeId { get; set; }
        public Size? Size { get; set; }
        public ICollection<Product> Products { get; } = new List<Product>();


    }
}
