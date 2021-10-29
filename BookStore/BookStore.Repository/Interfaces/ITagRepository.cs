using System;
using BookStore.Domain.Models;
using System.Collections.Generic;

namespace BookStore.Repository.Interfaces
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags(string searchString);
        Tag CreateTag(Tag category);
        Tag GetTag(Guid? tagId);
    }
}