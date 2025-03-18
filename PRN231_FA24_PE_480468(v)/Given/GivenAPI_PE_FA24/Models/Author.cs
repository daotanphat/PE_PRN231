using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GivenAPI_PE_FA24.Models
{
	public partial class Author
	{
		//public Author()
		//{
		//    Books = new HashSet<Book>();
		//}

		public int AuthorId { get; set; }
		public string Name { get; set; } = null!;
		public string? Bio { get; set; }
		//public virtual ICollection<Book> Books { get; set; }
	}
}
