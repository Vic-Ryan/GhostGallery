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
                LocationId = model.LocationId,
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

        public GhostDetail GetGhostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ghosts.Single(e => e.GhostId == id && e.OwnerId == _userId);
                return new GhostDetail
                {
                    GhostId = entity.GhostId,
                    Name = entity.Name,
                    LocationId = entity.LocationId,
                    Location = entity.Location,
                    Type = entity.Type,
                    FirstSighting = entity.FirstSighting,
                    Appearance = entity.Appearance,
                    Description = entity.Description,
                    ThreatLevel = entity.ThreatLevel,
                    Powers = entity.Powers
                };
            }
        }

        public bool UpdateGhost(GhostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ghosts.Single(e => e.GhostId == model.GhostId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.LocationId = model.LocationId;
                entity.Type = model.Type;
                entity.FirstSighting = model.FirstSighting;
                entity.Appearance = model.Appearance;
                entity.Description = model.Description;
                entity.ThreatLevel = model.ThreatLevel;
                entity.Powers = model.Powers;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGhost(int ghostId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ghosts.Single(e => e.GhostId == ghostId && e.OwnerId == _userId);

                ctx.Ghosts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
