using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using programming009.LibraryManagement.WebApi.Models;
using programming009.LibraryManagement.WebApi.Services.Abstract;

namespace programming009.LibraryManagement.WebApi.Controllers
{
    //RESTfull
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult Post(BookModel model)
        {
            _bookService.Add(model);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(BookModel model, int id)
        {
            model.Id = id;

            _bookService.Update(model);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BookModel res = _bookService.Get(id);

            return Ok(res);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<BookModel> books = _bookService.Get();

            return Ok(books);
        }
    }
}
