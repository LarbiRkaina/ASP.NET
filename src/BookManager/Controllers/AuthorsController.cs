using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManager.Application;
using BookManager.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private readonly AuthorService _authorservice;

        public AuthorsController(
            AuthorService authorservice)
        {
            _authorservice = authorservice;
        }

        // Add Author
        [HttpPost("")]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            await _authorservice.AddAuthor(author);
            return Ok();
        }
    }
}
