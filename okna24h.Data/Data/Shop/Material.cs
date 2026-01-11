using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Shop
{
    public class Material
    {
        public int MaterialId { get; set; }
        [Required(ErrorMessage = "Nazwa  jest wymagana")]
        [MaxLength(30, ErrorMessage = "Nazwa powinna mieć max 30 znakow")]
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        [Display(Name = "URL zdjęcia")]
        public required string PhotoUrl { get; set; }
        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        public ICollection<MaterialType> MaterialTypes { get; } = new List<MaterialType>();

    }
}
