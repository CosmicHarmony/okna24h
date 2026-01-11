using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.CMS
{
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł Url-a")]
        [MaxLength(10, ErrorMessage = "Tytuł powinien zawierać max 10 znaków")]
        [Display(Name = "Tytuł Odnośnika")]
        public required string TitleUrl { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł")]
        [MaxLength(30, ErrorMessage = "Tytuł powinien zawierać max 30 znaków")]
        [Display(Name = "Tytuł")]
        public required string Title { get; set; }
        [Display(Name = "Zdjęcie strony")]
        [MaxLength(200)]
        public string? PhotoUrl { get; set; }
        [Required(ErrorMessage = "Wpisz treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Treść")]
        public required string Content { get; set; }

        [Required(ErrorMessage = "Podaj dostęp")]
        [Display(Name = "Dostep")]
        public int AccesId { get; set; }
        [Required(ErrorMessage = "Wpisz pozycję")]
        [Display(Name = "Pozycja wyświetlania")]
        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        public int Position { get; set; }
        [Display(Name = "Access level")]
        public AccessLevel AccessLevel { get; set; } = AccessLevel.Public;
    }
}
