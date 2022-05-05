using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Models
{
    public class GhostEdit
    {
        public int GhostId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Haunt Location")]
        public int? Location { get; set; }
        public string Type { get; set; }
        [Display(Name = "First Sighting")]
        public DateTimeOffset FirstSighting { get; set; }
        public string Appearance { get; set; }
        public string Description { get; set; }
        [Display(Name = "Threat Level")]
        public int ThreatLevel { get; set; }
        public string Powers { get; set; }
    }
}
