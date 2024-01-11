using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Business;
using RestWithAspNet.Data.VO;
using RestWithAspNet.Hypermedia.Filter;
using RestWithAspNet.Model;

namespace WebApplication1.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _BookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness BookBusiness)
        {
            _logger = logger;
            _BookBusiness = BookBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_BookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var Book = _BookBusiness.FindById(id);
            if (Book == null) { return NotFound(); }
            return Ok(Book);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null) { return BadRequest(); }
            return Ok(_BookBusiness.Create(book));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null) { return BadRequest(); }
            return Ok(_BookBusiness.Update(book));
        }


        [HttpDelete("{id}")]
        public IActionResult delete(long id)
        {
            _BookBusiness.Delete(id);
            return NoContent();
        }

    }
}
