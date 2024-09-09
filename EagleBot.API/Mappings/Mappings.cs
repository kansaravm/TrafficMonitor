using AutoMapper;
using EagleBot.API.Dtos;

namespace EagleBot.API.Mappings
{
    public sealed class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CreateEagleBotRequest, Models.EagleBot>();
        }
    }
}
