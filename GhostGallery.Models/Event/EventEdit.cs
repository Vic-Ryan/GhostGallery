using GhostGallery.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Models.Event
{
    public class EventEdit
    {
        [Display(Name = "Event Id")]
        public int EventId { get; set; }
        [Display(Name = "Event Date")]
        public DateTimeOffset EventDate { get; set; }
        [Display(Name = "Ghost ID")]
        public int? GhostId { get; set; }
        public string Description { get; set; }
        public string Equipment { get; set; }
    }
}
