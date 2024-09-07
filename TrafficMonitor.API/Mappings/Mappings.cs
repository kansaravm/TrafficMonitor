using AutoMapper;
using TrafficMonitor.Common.Models;
using TrafficMonitorAPI.Dtos;


namespace TrafficMonitor.Mappings
{
    public sealed class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<TrafficDataRequest, TrafficData>()               
                .ForPath(dest => dest.Location.Latitude, opt => opt.MapFrom(src => src.Latitude))
                  .ForPath(dest => dest.Location.Longitude, opt => opt.MapFrom(src => src.Longitude));
;

            CreateMap<TrafficData, TrafficDataResponse>()               
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.Longitude));

        }
    }
}
