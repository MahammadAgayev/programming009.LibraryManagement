using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Enums;
using programming009.LibraryManagement.Core.Domain.Repositories;
using programming009.LibraryManagementWeb.Mappers;
using programming009.LibraryManagementWeb.Models;

namespace programming009.LibraryManagementWeb.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Book> books = _unitOfWork.BookRepository.Get();

            List<BookModel> models = new List<BookModel>();

            foreach(Book b in books)
            {
                BookModel m = BookMapper.Map(b);

                models.Add(m);
            }

            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            BookModel model = new BookModel();
            this.FillGenres();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(BookModel model)
        {
            if(ModelState.IsValid == false) 
            {
                this.FillGenres();
                return View(model);
            }

            Book b = BookMapper.Map(model);
            _unitOfWork.BookRepository.Add(b);

            return RedirectToAction("Index");
        }

        private void FillGenres()
        {
            ViewBag.Genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().
                Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString()
                }).ToList();
        }
    }
}
