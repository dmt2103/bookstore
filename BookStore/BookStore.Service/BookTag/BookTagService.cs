using AutoMapper;
using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using BookStore.Repository.Interfaces;
using System;

namespace BookStore.Service.BookTag
{
    public class BookTagService : IBookTagService
    {
        private readonly IBookTagRepository _bookTagRepository;
        private readonly IMapper _mapper;

        public BookTagService(IBookTagRepository bookTagRepository, IMapper mapper)
        {
            _bookTagRepository = bookTagRepository;
            _mapper = mapper;
        }

        public BookTagResponseModel CreateTag(BookTagRequestModel request)
        {
            var bookTag = _bookTagRepository.CreateBookTag(request);
            var response = _mapper.Map<Domain.Models.BookTag, BookTagResponseModel>(bookTag);

            return response;
        }

        public void DeleteBookTagByTagId(Guid request)
        {
            _bookTagRepository.DeleteBookTagByTagId(request);
        }

        public void DeleteBookTagByBookId(Guid request)
        {
            _bookTagRepository.DeleteBookTagByBookId(request);
        }
    }
}