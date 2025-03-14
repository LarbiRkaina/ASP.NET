using System;
using BookManager.Application.Models;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Application
{
	public class BookService
	{
		private readonly IBookDbContext _bookDbContext;

		public BookService(IBookDbContext bookDbContext)
		{
			_bookDbContext = bookDbContext;
		}


        public async Task <Book> GetBookById(int id)
		{
			var bookEntity = await _bookDbContext.Books.AsNoTracking()
				.Include(r => r.Author)
				.Where(b => b.Id == id)
                .FirstOrDefaultAsync();

			var book = new Book();
			if (bookEntity is null)
			{
				throw new ArgumentNullException (nameof(id));
			}
			book.Title = bookEntity.Title;
			book.Description = bookEntity.Description;
			book.AuthorId = bookEntity.AuthorId;
			book.Author = bookEntity.Author.Name + " " + bookEntity.Author.Lastname;
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

		public List<Book> GetAllBooks()
		{
			var booksEntity = _bookDbContext.Books.Include(b => b.Author).ToList();
			List <Book> booksList = new List<Book>();

			foreach (var book  in booksEntity)
			{
                var libro = new Book();
                libro.Title = book.Title;
                libro.Description = book.Description;
				libro.PublishedOn = book.PublishedOn;
				libro.Author = book.Author.Name + " " + book.Author.Lastname;
				libro.AuthorId = book.AuthorId;

                booksList.Add(libro);

            }
			return booksList;
        }

		public async Task UpdateBook(int id, BookUpdate bookupdated)
		{
            var bookEntity = _bookDbContext.Books
				.Include(b => b.Author)
                .Where(b => b.Id ==id)
                .FirstOrDefault();

			bookEntity.Description = bookupdated.Description;
			bookEntity.Title = bookupdated.Title;
  
            await _bookDbContext.SaveChangesAsync();

        }
		
    }
}

