using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using System;

namespace BookStore.Service.BookTag
{
    public interface IBookTagService
    {
        BookTagResponseModel CreateTag(BookTagRequestModel request);
        void DeleteBookTagByTagId(Guid request);
        void DeleteBookTagByBookId(Guid request);
    }
}