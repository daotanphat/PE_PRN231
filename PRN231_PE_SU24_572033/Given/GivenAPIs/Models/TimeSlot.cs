using System;
using System.Collections.Generic;

namespace GivenAPIs.Models
{
    public partial class TimeSlot
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
