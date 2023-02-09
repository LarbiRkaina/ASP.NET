using System;
namespace BookManager.Application.Models
{
	public class Author
	{
		public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public DateTime Birth { get; set; }

    }
}

