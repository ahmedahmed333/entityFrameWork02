using entityFrameWork02.Data;
using entityFrameWork02.Models;
using entityFrameWork02.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace entityFrameWork02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new EventHubContext();
            db.Database.Migrate();

            var organizer = new Organizer
            {
                Name = "Ahmed",
                CompanyName = "Route",
                IsVerified = true,
                Profile = new OrganizerProfile { Biography = "Event pro", WebsiteUrl = "https://route.com" },
                Events =
    {
        new Event { Title = "ASP.NET Day", Description = "Workshop",
                    StartDate = DateTime.Today.AddDays(7), MaxAttendees = 100 }
    }
            };

            var attendee = new Attendee
            {
                FullName = "Sara Ali",
                Email = "sara@mail.com",
                Street = "10 Nile St",
                City = "Giza",
                Country = "Egypt",
                PostalCode = "12511",
                Badge = new Badge { BadgeNumber = "B-0001", IssuedDate = DateTime.Today, Tier = BadgeTier.VIP }
            };

            db.AddRange(organizer, attendee);
            db.SaveChanges();

            Console.WriteLine(attendee.FullAddress);
        }
    }
}
