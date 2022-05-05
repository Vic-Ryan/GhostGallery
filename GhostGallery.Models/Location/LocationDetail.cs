using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Models
{
    public class LocationDetail
    {
        [Display(Name="Location ID")]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name="Ghost(s)")]
        public int? Ghosts { get; set; }
    }
}
