using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Models.Event
{
    public class EventCreate
    {
        [Display(Name = "Event Date")]
        public DateTimeOffset EventDate { get; set; }
        public int? GhostId { get; set; }
        public string Description { get; set; }
        public string Equipment { get; set; }
    }
}
