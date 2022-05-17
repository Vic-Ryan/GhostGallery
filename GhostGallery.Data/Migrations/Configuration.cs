namespace GhostGallery.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GhostGallery.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GhostGallery.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Locations.AddOrUpdate(l => l.LocationId, new Location() { LocationId = 1, Name = "Ridgeview Roadhouse", Address = "4865 Ridgeview Way, Butte, MT" },
                new Location() { LocationId = 2, Name = "Bleasedale Farmhouse", Address = "1378 Bleasdale Street, Lewiston, ID" },
                new Location() { LocationId = 3, Name = "Edgefield Streethouse", Address = "68874 Edgefield Road, Temecula, CA" }
                );

            context.Ghosts.AddOrUpdate(g => g.GhostId, new Ghost() { GhostId = 1, Name = "Luke Wilson", LocationId = 1, Type = "Raiju", FirstSighting = new DateTimeOffset (2020,3,8,9,23,00, new TimeSpan(-5,0,0)), Appearance = "Shadowy silhouette, no real discernable features", Description = "No previous reports of violence, but noticeable action in throwing items and other disturbances. Responded to those who were alone.", ThreatLevel = 4, Powers = "Electrical Interruption and Siphoning, Telekenisis" },
                new Ghost() { GhostId = 2, Name = "Brian Buckley", LocationId = 2, Type = "Revenant", FirstSighting = new DateTimeOffset(2021, 5, 28, 3, 26, 0, new TimeSpan(-5, 0, 0)), Appearance = "Older gentleman, noticeable signs of decay on body, dressed in a dirty suit, or what's left of it.", Description = "Appearance began after the use of a cursed object, later found to be a cursed mirror. Reports of minor violence against tennants.", ThreatLevel = 5, Powers = "Physical Altercations, Enhanced Speed" },
                new Ghost() { GhostId = 3, Name = "Julie Ramirez", LocationId = 3, Type = "Demon", FirstSighting = new DateTimeOffset(2022, 5, 16, 11, 15, 00, new TimeSpan(-5, 0, 0)), Appearance = "Female believed to be around middle-aged, with noticeably receeding hairline and multiple scars and bloodstains covering the body.", Description = "Previous reports of violence towards homeowners, along with multiple other disturbances. Believed to be highly dangerous.", ThreatLevel = 8, Powers = "Extreme Activity, Increased Hunting Activity, Attacking with Extreme Prejudice" }
                );

            context.Events.AddOrUpdate(e => e.EventId, new Event() { EventId = 1, EventDate = new DateTimeOffset(2020, 4, 23, 1, 45, 16, new TimeSpan(-5, 0, 0)), GhostId = 1, Description = "Human Skull found, believed to have connection to spirit.", Equipment = "Photo Camera" },
                new Event() { EventId = 2, EventDate = new DateTimeOffset(2020, 4, 23, 1, 50, 23, new TimeSpan(-5, 0, 0)), GhostId = 1, Description = "Apparition spotted standing still in corner, photo taken.", Equipment = "Photo Camera" },
                new Event() { EventId = 3, EventDate = new DateTimeOffset(2020, 4, 23, 1, 51, 45, new TimeSpan(-5, 0, 0)), GhostId = 1, Description = "Lightbulb burst in room with two hunters in it after previously being off. No injuries.", Equipment = "N/A" },
                new Event() { EventId = 4, EventDate = new DateTimeOffset(2020, 4, 23, 1, 45, 16, new TimeSpan(-5, 0, 0)), GhostId = 1, Description = "Ghost Orbs spotted in room with other equipment set up. Video camera later checked, working fine.", Equipment = "Video Camera" },
                new Event() { EventId = 5, EventDate = new DateTimeOffset(2021, 6, 4, 12, 10, 12, new TimeSpan(-5, 0, 0)), GhostId = 2, Description = "Freezing temperatures noted, air noticeably visible", Equipment = "Thermometer" },
                new Event() { EventId = 6, EventDate = new DateTimeOffset(2021, 6, 4, 12, 12, 51, new TimeSpan(-5, 0, 0)), GhostId = 2, Description = "Candle set up previously suddenly blown out.", Equipment = "Candle, Video Camera" },
                new Event() { EventId = 7, EventDate = new DateTimeOffset(2021, 6, 4, 12, 14, 24, new TimeSpan(-5, 0, 0)), GhostId = 2, Description = "Voice not belonging to any of the hunters heard elsewhere in the house, no other signs of life.", Equipment = "Parabolic Microphone" },
                new Event() { EventId = 8, EventDate = new DateTimeOffset(2021, 6, 4, 12, 15, 31, new TimeSpan(-5, 0, 0)), GhostId = 2, Description = "Ghost writing spotted in spirit book, nothing more than scribbles.", Equipment = "Spirit Book" },
                new Event() { EventId = 9, EventDate = new DateTimeOffset(2022, 5, 21, 8, 15, 16, new TimeSpan(-5, 0, 0)), GhostId = 3, Description = "Door noted to have suddenly opened on its own, fingerprints later spotted by UV light.", Equipment = "UV Flashlight, Photo Camera" },
                new Event() { EventId = 10, EventDate = new DateTimeOffset(2022, 5, 21, 8, 17, 23, new TimeSpan(-5, 0, 0)), GhostId = 3, Description = "Bathroom faucet turned on, pouring dirty water into sink.", Equipment = "Photo Camera" },
                new Event() { EventId = 11, EventDate = new DateTimeOffset(2022, 5, 21, 8, 19, 45, new TimeSpan(-5, 0, 0)), GhostId = 3, Description = "Footprints spotted after ghost walked through pile of salt, made clear through UV Glowstick.", Equipment = "UV Glowstick, Salt" },
                new Event() { EventId = 12, EventDate = new DateTimeOffset(2022, 5, 21, 8, 21, 7, new TimeSpan(-5, 0, 0)), GhostId = 3, Description = "Motion sensor tripped, no other person nearby to trip it.", Equipment = "Motion Sensor" }
            );
        }
    }
}
