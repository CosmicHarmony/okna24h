using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.CMS
{
    public class Website
    {
        [Key]
        public int WebsiteID { get; set; }
        [Required(ErrorMessage = "Wpisz tytuł odnośnika")]
        [MaxLength(10, ErrorMessage = "Tytuł powinien zawierać max 10 znaków")]
        [Display(Name = "Tytuł odnośnika")]
        public required string TitleURL { get; set; }
        [Required(ErrorMessage = "Wpisz tytuł strony")]
        [MaxLength(30, ErrorMessage = "Tytuł powinien zawierać max 30 znaków")]
        [Display(Name = "Tytuł")]
        public required string Title { get; set; }
        [Display(Name = "Opis")]
        [MaxLength(100, ErrorMessage = "Opis powinien zawierać max 100 znaków")]
        public string? Description { get; set; }

        [Display(Name = "Słowa kluczowe")]
        [MaxLength(100, ErrorMessage = "Słowa kluczowe powinny zawierać max 100 znaków")]
        public string? Keywords { get; set; }
        [Display(Name = "Zdjęcie strony")]
        [MaxLength(200)]
        public string? PhotoUrl { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Required(ErrorMessage = "Wpisz treść strony")]
        public required string Content { get; set; }
        [Display(Name = "Pozycja Wyswietlania")]
        [Required(ErrorMessage = "Wpisz pozycję wyświetlania")]
        public int Item { get; set; }
        public required bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public required DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        [Display(Name = "Access level")]
        public AccessLevel AccessLevel { get; set; } = AccessLevel.Public;
    }
}
