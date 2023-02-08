using System;
namespace BookManager.Application.Models
{
	public class Book
	{
		public string Title { get; set; } = string.Empty;
		public DateTime PublishedOn { get; set; }
		public string Description { get; set; } = string.Empty;
		public int AuthorId { get; set; }
	}
}

