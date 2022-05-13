using GhostGallery.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Models.Event
{
    public class EventListItem
    {
        [Display(Name ="Event ID")]
        public int EventId { get; set; }
        [Display(Name = "Event Date")]
        public DateTimeOffset EventDate { get; set; }
        public Ghost Ghost { get; set; }
    }
}
