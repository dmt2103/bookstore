using System;
using BookStore.Domain.Models;
using System.Collections.Generic;
using BookStore.Contract.RequestModels;

namespace BookStore.Repository.Interfaces
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags(string searchString);
        Tag CreateTag(TagRequestModel tag);
        Tag GetTag(Guid? tagId);
    }
}