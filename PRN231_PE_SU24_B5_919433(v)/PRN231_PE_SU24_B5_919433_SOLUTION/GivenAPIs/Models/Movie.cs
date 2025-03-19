using System;
using System.Collections.Generic;

namespace GivenAPIs.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? Year { get; set; }
        public string? Description { get; set; }
        public int DirectorId { get; set; }

    }
}
