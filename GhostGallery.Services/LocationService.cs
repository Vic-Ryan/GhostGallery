using GhostGallery.Data;
using GhostGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostGallery.Services
{
    public class LocationService
    {
        //private readonly Guid _userId;

        public LocationService()
        {
           // _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity = new Location()
            {
                Name = model.Name,
                Address = model.Address,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Locations.Select(e => new LocationListItem
                {
                    LocationId = e.LocationId,
                    Name = e.Name,
                    Address = e.Address
                });
                return query.ToArray();
            }
        }

        public LocationDetail GetLocationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(e => e.LocationId == id); //UserId
                return new LocationDetail
                {
                    LocationId = entity.LocationId,
                    Name = entity.Name,
                    Address = entity.Address,
                };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(e => e.LocationId == model.LocationId); //UserId

                entity.LocationId = model.LocationId;
                entity.Name = model.Name;
                entity.Address = model.Address;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(e => e.LocationId == locationId); //UserId

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
