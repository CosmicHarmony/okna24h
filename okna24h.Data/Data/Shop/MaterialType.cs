using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Shop
{
    public class MaterialType
    {
        public int MaterialTypeId { get; set; }
        [ForeignKey("Material")]
        public int MaterialId { get; set; }
        public Material? Material { get; set; }
        [ForeignKey("Typ")]
        public int? TypeId { get; set; }
        public Typ? Typ { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
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
        public ICollection<MaterialTypeColor> MaterialTypeColors { get; } = new List<MaterialTypeColor>();
    }
}
