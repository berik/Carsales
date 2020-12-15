using AutoMapper;
using Core.Entities;

namespace WebApp.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDto>();
            CreateMap<NewCarDto, Car>();
            
        }
    }
}