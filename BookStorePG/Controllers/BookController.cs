using Microsoft.AspNetCore.Mvc;
using BookStorePG.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookStorePG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        ApplicationDBContext _context { get; set; }
        public BookController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<BookDto> GetAll()
        {
            List<Book> books = _context.Books.ToList();
            List<BookDto> result = [];
            foreach(Book book in books)
            {
                Author author = _context.Authors.FirstOrDefault(x => x.Id == book.AuthorId);
                result.Add(new BookDto(book, author));
            }

            return result;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Book> GetById([FromRoute] int id)
        {
            Book? result = _context.Books.FirstOrDefault(x=>x.Id == id);
            if(result == null)
            {
                return NotFound("Book Not Found");
            }
            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            Book? result = _context.Books.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound("Book Not Found");
            }
            _context.Remove(result);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return Created();
        }
    }
}
