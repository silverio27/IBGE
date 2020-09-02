using AutoMapper;
using Ibge.Domain.RegionIbgeContext.Commands.Contracts;
using Ibge.Domain.RegionIbgeContext.Entities;

namespace Ibge.Domain.RegionIbgeContext.Mapping.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionCommand>()
            .ForMember(dto => dto.id, map => map.MapFrom(src => src.Id))
            .ForMember(dto => dto.sigla, map => map.MapFrom(src => src.Initials))
            .ForMember(dto => dto.nome, map => map.MapFrom(src => src.Name))
            .ReverseMap()
            .ForMember(map => map.Id, dto => dto.MapFrom(src => src.id))
            .ForMember(map => map.Initials, dto => dto.MapFrom(src => src.sigla))
            .ForMember(map => map.Name, dto => dto.MapFrom(src => src.nome));
        }
    }
}