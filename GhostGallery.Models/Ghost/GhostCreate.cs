using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Models
{
    public class GhostCreate
    {
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public string Type { get; set; }
        public DateTimeOffset FirstSighting { get; set; }
        public string Appearance { get; set; }
        public string Description { get; set; }
        [Range(1, 10, ErrorMessage = "Please enter a number between 1 and 10.")]
        public int ThreatLevel { get; set; }
        public string Powers { get; set; }
    }
}
