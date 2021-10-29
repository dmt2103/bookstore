using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using BookStore.Contract.RequestModels;

namespace BookStore.Repository.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks(string searchString);
        Book CreateBook(BookRequestModel book);
        Book GetBook(Guid? bookId);
        Book UpdateBook(BookRequestModel book);
        void DeleteBook(Guid bookId);
    }
}