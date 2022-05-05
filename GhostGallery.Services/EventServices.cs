using GhostGallery.Data;
using GhostGallery.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Services
{
    public class EventServices
    {
        private readonly Guid _userId;

        public EventServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity = new Event()
            {
                OwnerId = _userId,
                EventDate = model.EventDate,
                Ghost = model.Ghost,
                Description = model.Description,
                Equipment = model.Equipment
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Events.Select(e => new EventListItem
                {
                    EventId = e.EventId,
                    EventDate = e.EventDate,
                    Ghost = e.Ghost
                });
                return query.ToArray();
            }
        }

        public EventDetail GetEventById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Events.Single(e => e.EventId == id && e.OwnerId == _userId);
                return new EventDetail
                {
                    EventId = entity.EventId,
                    EventDate = entity.EventDate,
                    Ghost = entity.Ghost,
                    Description = entity.Description,
                    Equipment = entity.Equipment
                };
            }
        }

        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Events.Single(e => e.EventId == model.EventId && e.OwnerId == _userId);

                entity.EventId = model.EventId;
                entity.EventDate = model.EventDate;
                entity.Ghost = model.Ghost;
                entity.Description = model.Description;
                entity.Equipment = model.Equipment;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEvent(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Events.Single(e => e.EventId == eventId && e.OwnerId == _userId);

                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
