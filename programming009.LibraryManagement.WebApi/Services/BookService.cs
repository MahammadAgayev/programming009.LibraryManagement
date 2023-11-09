using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;
using programming009.LibraryManagement.WebApi.Models;
using programming009.LibraryManagement.WebApi.Services.Abstract;

namespace programming009.LibraryManagement.WebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(BookModel model)
        {
            Book b = BookMapper.ToBook(model);

            _unitOfWork.BookRepository.Add(b);
        }

        public List<BookModel> Get()
        {
            List<Book> books = _unitOfWork.BookRepository.Get();

            List<BookModel> models = new List<BookModel>();

            foreach (Book book in books) 
            {
                BookModel model = BookMapper.ToBookModel(book);

                models.Add(model);
            }

            return models;
        }

        public BookModel Get(int id)
        {
            Book b = _unitOfWork.BookRepository.Get(id);

            if(b == null)
            {
                throw new NotFoundException("Book not found");
            }

            BookModel m = BookMapper.ToBookModel(b);

            return m;
        }

        public void Update(BookModel model)
        {
            Book original = _unitOfWork.BookRepository.Get(model.Id);

            if(original == null)
            {
                throw new NotFoundException($"Book not found with id {model.Id}");
            }

            Book b = BookMapper.ToBook(model);

            _unitOfWork.BookRepository.Update(b);
        }
    }
}
