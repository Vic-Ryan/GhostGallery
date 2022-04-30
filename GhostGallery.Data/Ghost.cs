using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Data
{
    public class Ghost
    {
        [Key]
        public int GhostId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Haunt Location")]
        public int? Location { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Display(Name="First Sighting")]
        public DateTimeOffset FirstSighting { get; set; }
        [Required]
        public string Appearance { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ThreatLevel { get; set; }
        [Required]
        public string Powers { get; set; }
    }
}
