using AutoMapper;
using SignalR.DtoLayer.MoneyCaseActionDto;
using SignalR.EntityLayer.Entities;

namespace SiqnalRApi.Mapping
{
    public class MoneyCaseActionMapping : Profile
    {
        public MoneyCaseActionMapping() 
        {
            CreateMap<MoneyCaseAction, ResultMoneyCaseActionDto>().ReverseMap();
        }
    }
}
