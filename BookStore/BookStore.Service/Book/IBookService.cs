using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using System;
using System.Collections.Generic;

namespace BookStore.Service.Book
{
    public interface IBookService
    {
        List<BookResponseModel> GetAllBooks(string searchString);
        BookResponseModel CreateBook(BookRequestModel request);
        BookResponseModel GetBook(Guid? request);
        BookResponseModel UpdateBook(BookRequestModel request);
        void DeleteBook(Guid request);
    }
}