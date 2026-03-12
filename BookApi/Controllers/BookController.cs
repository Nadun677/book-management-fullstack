using Microsoft.AspNetCore.Mvc;
using BookApi.Models;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Angular Guide",
                Author = "John Doe",
                Isbn = "12345",
                PublicationDate = DateTime.Now
            }
        };

        // GET all books
        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            return books;
        }

        // GET book by id
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            return book;
        }

        // ADD book
        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            book.Id = books.Count + 1;
            books.Add(book);
            return Ok(book);
        }

        // UPDATE book
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Isbn = updatedBook.Isbn;
            book.PublicationDate = updatedBook.PublicationDate;

            return NoContent();
        }

        // DELETE book
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            books.Remove(book);
            return NoContent();
        }
    }
}