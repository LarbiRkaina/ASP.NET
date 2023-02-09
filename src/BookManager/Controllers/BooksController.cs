using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManager.Application;
using BookManager.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookManager.Application.Models;
using System.Net;

namespace BookManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookservice;

        public BooksController(
            BookService bookservice)
        {
            _bookservice = bookservice;
        }

        //Get one book by his Id
        [HttpGet("{bookId:int}")]
        public async Task<IActionResult> GetBook(int bookId)
        {
            var book = await _bookservice.GetBookById(bookId);
            return Ok(book);
        }

        // Add book
        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {

            await _bookservice.AddBook(book);
            return Ok(book);
        }

        // Get all books
        [HttpGet("")]
        public List<Book> GetAllBooks()
        {
            return _bookservice.GetAllBooks();
            
        }

        // Update the fields title and description from one book
        [HttpPut("{bookId:int}")]
        public async Task <IActionResult> UpdteBook(int bookId, [FromBody] BookUpdate bookupdated)
        {
            await _bookservice.UpdateBook(bookId, bookupdated);
            return Ok(bookupdated);
            
        }
    }
}
