using BookStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public List<Author> allAuthors = new List<Author>()
        {
            new Author() { AuthorId = 1, AuthorName = "J.K. Rowling"},
            new Author() { AuthorId = 2, AuthorName = "Robert Kiosaki"},
            new Author() { AuthorId = 3, AuthorName = "Robert Frost"},
        };

        [Route("")]
        public IActionResult GetAllAuthors()
        {
            return Ok(allAuthors);
        }

        [Route("/{AuthorId}")]
        public IActionResult GetAuthorById(int AuthorId)
        {
            return Ok(allAuthors.Where(a=>a.AuthorId == AuthorId));
        }

        [HttpPost("")]
        public IActionResult AddAuthor(Author author)
        {
            allAuthors.Add(author);
            return Created("~/api/[controller]/"+author.AuthorId,author);
        }
    }
}
