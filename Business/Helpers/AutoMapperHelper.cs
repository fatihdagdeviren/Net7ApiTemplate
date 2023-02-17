using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Zone;

namespace Business.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<CreateZoneDto, Zone>();
            CreateMap<UpdateZoneDto, Zone>();
            CreateMap<ZoneDto, Zone>();
            CreateMap<Zone, ZoneDto>();
        }
    }
}