using System;
using System.Collections.Generic;

namespace GivenAPI_PE_FA24.Models
{
    public partial class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string? Publisher { get; set; }
        public int? PublicationYear { get; set; }


        public virtual ICollection<Author> Authors { get; set; }
    }
}
