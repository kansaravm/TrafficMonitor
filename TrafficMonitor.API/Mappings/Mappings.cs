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
            CreateMap<CreateTrafficDataRequest, TrafficData>()
                .ForPath(dest => dest.Location.Latitude, opt => opt.MapFrom(src => src.Latitude))
                  .ForPath(dest => dest.Location.Longitude, opt => opt.MapFrom(src => src.Longitude));
            ;

            CreateMap<TrafficData, TrafficDataResponse>()
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.Longitude));

            CreateMap<TrafficDataResponse, TrafficData>()
                .ForPath(dest => dest.Location.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForPath(dest => dest.Location.Longitude, opt => opt.MapFrom(src => src.Longitude));

            CreateMap<GetTrafficFilterRequest, GetTrafficFilter>();

            CreateMap<IPagedList<TrafficData>, GetTrafficDataResponse>()
                .ConstructUsing((src, dest) => new GetTrafficDataResponse
                {
                    Paging = dest.Mapper.Map<Paging>(src),
                    TrafficDataResponses = dest.Mapper.Map<List<TrafficDataResponse>>(src)
                });

           
            CreateMap<IPagedList<TrafficData>, GetTrafficDataResponse>()
               .ForMember(dest => dest.Paging, opt => opt.MapFrom(src => new Paging()
               {
                   PageSize = src.PageSize,
                   PageNumber = src.PageNumber,
                   FirstItemOnPage = src.FirstItemOnPage,
                   LastItemOnPage = src.LastItemOnPage,
                   HasNextPage = src.HasNextPage,
                   HasPreviousPage = src.HasPreviousPage,
                   IsFirstPage = src.IsFirstPage,
                   IsLastPage = src.IsLastPage,
                   PageCount = src.PageCount,
                   TotalItemCount = src.TotalItemCount,

               }))
                .ForMember(dest => dest.TrafficDataResponses, opt => opt.MapFrom(src => src)); 
        }
    }
}
