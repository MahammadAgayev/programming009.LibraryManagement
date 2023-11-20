﻿using FluentValidation;
using FluentValidation.Results;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;
using programming009.LibraryManagement.WebApi.Models;
using programming009.LibraryManagement.WebApi.Services.Abstract;

namespace programming009.LibraryManagement.WebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BookService> _logger;
        private readonly IValidator<BookModel> _validator;

        public BookService(IUnitOfWork unitOfWork, ILogger<BookService> logger, IValidator<BookModel> validator)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _validator = validator;
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

            _logger.LogInformation($"there are {books.Count} books");

            return models;
        }

        public BookModel Get(int id)
        {
            Book b = _unitOfWork.BookRepository.Get(id);

            if (b == null)
                throw new NotFoundException($"Book not found with id {id}");

            BookModel m = BookMapper.ToBookModel(b);

            return m;
        }

        public void Update(BookModel model)
        {
            ValidationResult result =  _validator.Validate(model);

            _logger.LogInformation("book model validated with result {result}", result.IsValid);

            Book original = _unitOfWork.BookRepository.Get(model.Id);

            if(original == null)
                throw new NotFoundException($"Book not found with id {model.Id}");

            Book b = BookMapper.ToBook(model);

            _unitOfWork.BookRepository.Update(b);
        }
    }
}
