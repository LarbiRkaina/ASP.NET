using System;
using BookManager.Application.Models;
using BookManager.Domain;

namespace BookManager.Application
{
	public class AuthorService
	{
        private readonly IBookDbContext _bookDbContext;

        public AuthorService(IBookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }


        public async Task AddAuthor(Author author)
        {
            var authortoadd = new AuthorEntity();
            authortoadd.Name = author.Name;
            authortoadd.Lastname = author.LastName;
            authortoadd.Birth = author.Birth;

            //CountryCode in format ISO 3166-1 alpha-2 code

            if (!string.IsNullOrEmpty(author.CountryCode) && author.CountryCode.Length > 2)
            {
                var Iso = author.CountryCode.Substring(0,2);
                authortoadd.CountryCode = Iso;

            } else
            {
                authortoadd.CountryCode = author.CountryCode;
            }

            _bookDbContext.Authors.Add(authortoadd);
            await _bookDbContext.SaveChangesAsync();
        }
    }
}

