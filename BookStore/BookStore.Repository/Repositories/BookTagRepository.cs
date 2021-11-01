using BookStore.Contract.RequestModels;
using BookStore.Domain.Models;
using BookStore.Repository.Data;
using BookStore.Repository.Interfaces;
using System;
using System.Linq;

namespace BookStore.Repository.Repositories
{
    public class BookTagRepository : IBookTagRepository
    {
        private readonly BookStoreContext _context;

        public BookTagRepository(BookStoreContext context)
        {
            _context = context;
        }

        public BookTag CreateBookTag(BookTagRequestModel request)
        {
            var bookTag = new BookTag
            {
                TagId = request.TagId,
                BookId = request.BookId
            };

            _context.Add(bookTag);
            _context.SaveChanges();

            return bookTag;
        }

        public void DeleteBookTagByTagId(Guid? tagId)
        {
            var bookTags = _context.BookTags.Where(bt => bt.TagId.Equals(tagId)).ToList();

            foreach (var item in bookTags)
            {
                _context.BookTags.Remove(item);
            }

            _context.SaveChanges();
        }

        public void DeleteBookTagByBookId(Guid? bookId)
        {
            var bookTags = _context.BookTags.Where(bt => bt.BookId.Equals(bookId)).ToList();

            foreach (var item in bookTags)
            {
                _context.BookTags.Remove(item);
            }

            _context.SaveChanges();
        }
    }
}