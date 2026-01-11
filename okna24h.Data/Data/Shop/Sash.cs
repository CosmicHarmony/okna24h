using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.Shop
{
    public class Sash
    {
        public int SashId { get; set; }
        public string Code { get; set; } = string.Empty;
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
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
        public ICollection<Article> Articles { get; } = new List<Article>();
    }
}
