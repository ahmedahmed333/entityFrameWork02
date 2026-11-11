using System;
using System.Collections.Generic;
using System.Text;

namespace entityFrameWork02.Models
{
    public class OrganizerProfile
    {
        public int Id { get; set; }
        public string? Biography { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? LogoUrl { get; set; }

        public int OrganizerId { get; set; }          // FK
        public Organizer Organizer { get; set; } = null!;

    }
}
