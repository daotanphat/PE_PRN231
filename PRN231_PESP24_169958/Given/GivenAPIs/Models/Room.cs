using System;
using System.Collections.Generic;

namespace GivenAPIs.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? Capacity { get; set; }
    }
}
