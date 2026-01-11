using okna24h.Data.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.CMS
{
    public class Media
    {
        [Key]
       public int MediaId { get; set; }
        public required string Title { get; set; }
        public required string Url { get; set; }
        public required string Type { get; set; } // e.g., "image", "video", etc.
        public string? AltText { get; set; }
        public string? Description { get; set; }

        public string FileType { get; set; } = string.Empty; // image/png, image/jpeg, pdf
        public long FileSize { get; set; }
        
        public bool IsActive { get; set; } = true;

        [Column(TypeName = "datetime")]
        public DateTime UploadDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime? EditDateTime { get; set; }

        [Column(TypeName = "datetime")]
        
        public DateTime? DeleteDateTime { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; } // Assuming this is the ID of the employee who uploaded the media
        public Employee? Employee { get; set; }



    }
}
