using BookStore.Contract.RequestModels;
using BookStore.Domain.Models;
using System;

namespace BookStore.Repository.Interfaces
{
    public interface IBookTagRepository
    {
        BookTag CreateBookTag(BookTagRequestModel bookTag);
        void DeleteBookTagByTagId(Guid? tagId);
        void DeleteBookTagByBookId(Guid? bookId);
    }
}