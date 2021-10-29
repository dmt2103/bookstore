using AutoMapper;
using BookStore.Contract.ResponseModels;

namespace BookStore.Service.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryResponseModel, Domain.Models.Category>().ReverseMap();
            CreateMap<BookResponseModel, Domain.Models.Book>().ReverseMap();
            CreateMap<TagResponseModel, Domain.Models.Tag>().ReverseMap();
        }
    }
}