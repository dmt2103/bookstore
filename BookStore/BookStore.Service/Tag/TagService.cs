using AutoMapper;
using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using BookStore.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace BookStore.Service.Tag
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public List<TagResponseModel> GetAllTags(string searchString)
        {
            var res = _tagRepository.GetAllTags(searchString);
            var allTags = _mapper.Map<List<Domain.Models.Tag>, List<TagResponseModel>>(res);

            return allTags;
        }

        public TagResponseModel CreateTag(TagRequestModel request)
        {
            var tag = _tagRepository.CreateTag(request);
            var response = _mapper.Map<Domain.Models.Tag, TagResponseModel>(tag);

            return response;
        }

        public TagResponseModel GetTag(Guid? request)
        {
            var res = _tagRepository.GetTag(request);
            var tag = _mapper.Map<Domain.Models.Tag, TagResponseModel>(res);

            return tag;
        }
    }
}