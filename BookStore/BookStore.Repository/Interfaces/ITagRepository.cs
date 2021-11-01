using BookStore.Contract.RequestModels;
using BookStore.Domain.Models;
using System;
using System.Collections.Generic;

namespace BookStore.Repository.Interfaces
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags(string searchString);
        Tag CreateTag(TagRequestModel tag);
        Tag GetTag(Guid? tagId);
        List<Tag> GetTagsByBookId(Guid? bookId);
        void DeleteTag(Guid? tagId);
    }
}