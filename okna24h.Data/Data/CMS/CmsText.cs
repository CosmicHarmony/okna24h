using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.CMS
{
    public class CmsText
    {
        [Key]
        public int TextId { get; set; }

        [Required]
        public required string Key { get; set; }

        [Required]
        public required string Language { get; set; }

        [Required]
        public required string Value { get; set; }

        // Category for grouping texts, if needed
        public required string Category { get; set; }
        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDateTime { get; set; }
        public AccessLevel AccessLevel { get; set; } = AccessLevel.Public;
    }
}
