using AutoMapper;
using SignalR.DtoLayer.CategoryDto;
using SiqnalR.EntityLayer.Entities;

namespace SiqnalRApi.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
               CreateMap<Category, ResultCategoryDto>().ReverseMap();
               CreateMap<Category, CreateCategoryDto>().ReverseMap();
               CreateMap<Category, GetCategoryDto>().ReverseMap();
               CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
