using AutoMapper;
using TrafficMonitor.Common.Models;
using TrafficMonitorAPI.Dtos;
using X.PagedList;


namespace TrafficMonitor.Mappings
{
    public sealed class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<TrafficDataRequestDto, TrafficData>()               
                .ForPath(dest => dest.Location.Latitude, opt => opt.MapFrom(src => src.Latitude))
                  .ForPath(dest => dest.Location.Longitude, opt => opt.MapFrom(src => src.Longitude));
;

            CreateMap<TrafficData, TrafficDataResponse>()               
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.Longitude));

            CreateMap<TrafficDataResponse, TrafficData>()
                .ForPath(dest => dest.Location.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForPath(dest => dest.Location.Longitude, opt => opt.MapFrom(src => src.Longitude));

            CreateMap<GetTrafficFilterDto, GetTrafficFilter>();

            CreateMap<IPagedList<TrafficData>, TrafficDataList>()
                .ConstructUsing((src, dest) => new TrafficDataList
                {
                    Paging = dest.Mapper.Map<Paging>(src),
                    TrafficDataResponses = dest.Mapper.Map<List<TrafficDataResponse>>(src)
                });

            CreateMap<IPagedList<TrafficData>, TrafficDataList>()
                .ForMember(dest => dest.TrafficDataResponses, opt => opt.MapFrom(src => src));
        }
    }
}
