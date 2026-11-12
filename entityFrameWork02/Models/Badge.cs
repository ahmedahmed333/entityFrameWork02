using entityFrameWork02.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace entityFrameWork02.Models
{
    public class Badge
    {
        public int Id { get; set; }
        public string BadgeNumber { get; set; } = null!;
        public DateTime IssuedDate { get; set; }
        public BadgeTier Tier { get; set; }

        public int AttendeeId { get; set; }           // FK
        public Attendee Attendee { get; set; } = null!;
    }
}
