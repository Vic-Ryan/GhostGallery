using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Models
{
    public class GhostListItem
    {
        [Display(Name="Ghost ID")]
        public int GhostId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        [Display(Name="First Sighting")]
        public DateTimeOffset FirstSighting { get; set; }
    }
}
