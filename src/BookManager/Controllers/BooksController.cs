using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManager.Application;
using BookManager.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookManager.Application.Models;

namespace BookManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookkService _bookservice;

        public BooksController(
            BookkService bookservice)
        {
            _bookservice = bookservice;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookservice.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook(Book book)
        {

            await _bookservice.AddBook(book);
            return Ok(book);
        }
    }
}
