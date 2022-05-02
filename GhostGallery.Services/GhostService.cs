using GhostGallery.Data;
using GhostGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Services
{
    public class GhostService
    {
        private readonly Guid _userId;

        public GhostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGhost(GhostCreate model)
        {
            var entity = new Ghost()
            {
                OwnerId = _userId,
                Name = model.Name,
                Location = model.Location,
                Type = model.Type,
                FirstSighting = model.FirstSighting,
                Appearance = model.Appearance,
                Description = model.Description,
                ThreatLevel = model.ThreatLevel,
                Powers = model.Powers
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ghosts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GhostListItem> GetGhosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ghosts.Select(e => new GhostListItem
                {
                    GhostId = e.GhostId,
                    Name = e.Name,
                    Type = e.Type,
                    FirstSighting = e.FirstSighting
                });
                return query.ToArray();
            }
        }
    }
}
