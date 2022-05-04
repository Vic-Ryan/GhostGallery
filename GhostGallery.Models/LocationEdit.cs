using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Models
{
    public class LocationEdit
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Ghosts { get; set; }
    }
}
