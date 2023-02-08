using System;
namespace BookManager.Domain
{
	public class BookEntity
	{
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedOn { get; set; }
        public string Description { get; set; } = string.Empty;
        public AuthorEntity Author { get; set; }
        public int AuthorId { get; set; }
    }
}

