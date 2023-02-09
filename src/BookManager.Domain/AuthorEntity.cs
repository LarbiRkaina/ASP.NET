using System;
namespace BookManager.Domain
{
	public class AuthorEntity
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime Birth { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public List<BookEntity> Books { get; set; } = new();
    }
}

