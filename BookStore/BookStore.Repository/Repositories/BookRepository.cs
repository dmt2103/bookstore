using BookStore.Contract.RequestModels;
using BookStore.Domain.Models;
using BookStore.Repository.Data;
using BookStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repository.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks(string searchString)
        {
            var listBook = _context.Books
                .Join(
                    _context.Categories,
                    book => book.CategoryId,
                    category => category.CategoryId,
                    (book, category) => new Book()
                    {
                        BookId = book.BookId,
                        BookName = book.BookName,
                        Description = book.Description,
                        Author = book.Author,
                        PublishDate = book.PublishDate,
                        CategoryId = book.CategoryId,
                        Category = category
                    });

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                listBook = listBook.Where(b => b.BookName.Contains(searchString));
            }

            return listBook.ToList();
        }

        public Book CreateBook(BookRequestModel request)
        {
            var newBook = new Book
            {
                BookId = Guid.NewGuid(),
                BookName = request.BookName,
                Description = request.Description,
                Author = request.Author,
                PublishDate = request.PublishDate,
                CategoryId = request.CategoryId
            };

            _context.Add(newBook);
            _context.SaveChanges();

            return newBook;
        }

        public Book GetBook(Guid? bookId)
        {
            if (bookId == null)
            {
                return null;
            }

            var book = _context.Books
                .Join(
                    _context.Categories,
                    book => book.CategoryId,
                    category => category.CategoryId,
                    (book, category) => new Book()
                    {
                        BookId = book.BookId,
                        BookName = book.BookName,
                        Description = book.Description,
                        Author = book.Author,
                        PublishDate = book.PublishDate,
                        CategoryId = book.CategoryId,
                        Category = category
                    }).FirstOrDefault(b => b.BookId.Equals(bookId));

            return book;
        }

        public Book UpdateBook(BookRequestModel request)
        {
            var book = GetBook(request.BookId);

            if (book == null)
            {
                return null;
            }

            book.BookName = request.BookName;
            book.Description = request.Description;
            book.Author = request.Author;
            book.PublishDate = request.PublishDate;
            book.CategoryId = request.CategoryId;

            _context.Update(book);
            _context.SaveChanges();

            return book;
        }

        public void DeleteBook(Guid bookId)
        {
            var book = GetBook(bookId);
            if (book == null) return;
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}