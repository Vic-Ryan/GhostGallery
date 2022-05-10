using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Data
{
    public class Location
    {
        [Key]
        [Required]
        public int LocationId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public virtual List<Ghost> Ghosts { get; set; }
    }
}
