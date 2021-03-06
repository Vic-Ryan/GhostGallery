using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        [Display(Name = "Event Date")]
        public DateTimeOffset EventDate { get; set; }
        [Required]
        [ForeignKey("Ghost")]
        public int? GhostId { get; set; }
        public virtual Ghost Ghost { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Equipment { get; set; }
    }
}
