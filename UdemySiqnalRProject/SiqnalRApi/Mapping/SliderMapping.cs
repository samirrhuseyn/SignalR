using AutoMapper;
using SignalR.DtoLayer.SlideDto;
using SignalR.EntityLayer.Entities;

namespace SiqnalRApi.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping() 
        {
            CreateMap<Slider, ResultSlideDto>().ReverseMap();
            CreateMap<Slider, CreateSlideDto>().ReverseMap();
            CreateMap<Slider, GetSlideDto>().ReverseMap();
            CreateMap<Slider, UpdateSlideDto>().ReverseMap();
        }
    }
}
