using System;
using System.Collections.Generic;
using System.Text;

namespace entityFrameWork02.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxAttendees { get; set; }

        public int OrganizerId { get; set; }          // FK
        public Organizer Organizer { get; set; } = null!;
    }
}
