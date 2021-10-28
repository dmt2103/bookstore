using AutoMapper;
using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;

namespace BookStore.Service.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryRequestModel, Domain.Models.Category>().ReverseMap();
            CreateMap<CategoryResponseModel, Domain.Models.Category>().ReverseMap();
        }
    }
}