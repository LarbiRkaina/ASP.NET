using System;
using BookManager.Application.Models;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Application
{
	public class BookkService
	{
		public IBookDbContext _bookDbContext;

		public BookkService(IBookDbContext bookDbContext)
		{
			_bookDbContext = bookDbContext;
		}


        public async Task <Book> GetBookById(int id)
		{
			var bookEn = _bookDbContext.Books.AsNoTracking()
				.Include(r => r.Author)
				.FirstOrDefault(b => b.Id == id);

			var book = new Book();
			book.Title = bookEn.Title;
			book.Description = bookEn.Description;
			book.AuthorId = bookEn.AuthorId;
			return book;
		}

		public async Task AddBook (Book book)
		{
			var BookEnt = new BookEntity();
			BookEnt.AuthorId = book.AuthorId;
			BookEnt.Description = book.Description;
			BookEnt.Title = book.Title;

			_bookDbContext.Books.Add(BookEnt);

            await _bookDbContext.SaveChangesAsync();
        }

    }
}

