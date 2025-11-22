using BookStorePG.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStorePG.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        ApplicationDBContext _context { get; set; }
        public AuthorController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Author> GetById(int id) 
        {
            Author? result = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound("Author Not Found");
            }
            return Ok(result);
        }
    }
}
