using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using System;
using System.Collections.Generic;

namespace BookStore.Service.Tag
{
    public interface ITagService
    {
        List<TagResponseModel> GetAllTags(string searchString);
        TagResponseModel CreateTag(TagRequestModel request);
        TagResponseModel GetTag(Guid? request);
        List<TagResponseModel> GetTagsByBookId(Guid? bookId);
        void DeleteTag(Guid request);
    }
}