using AutoMapper;
using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using BookStore.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace BookStore.Service.Book
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public List<BookResponseModel> GetAllBooks(string searchString)
        {
            var res = _bookRepository.GetAllBooks(searchString);
            var allBooks = _mapper.Map<List<Domain.Models.Book>, List<BookResponseModel>>(res);

            return allBooks;
        }

        public BookResponseModel CreateBook(BookRequestModel request)
        {
            var book = _bookRepository.CreateBook(request);
            var response = _mapper.Map<Domain.Models.Book, BookResponseModel>(book);

            return response;
        }

        public BookResponseModel GetBook(Guid? request)
        {
            var res = _bookRepository.GetBook(request);
            var book = _mapper.Map<Domain.Models.Book, BookResponseModel>(res);

            return book;
        }

        public BookResponseModel UpdateBook(BookRequestModel request)
        {
            var book = _bookRepository.UpdateBook(request);
            var response = _mapper.Map<Domain.Models.Book, BookResponseModel>(book);

            return response;
        }

        public void DeleteBook(Guid request)
        {
            _bookRepository.DeleteBook(request);
        }
    }
}