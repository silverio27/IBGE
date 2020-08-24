using AutoMapper;
using Ibge.Domain.Dto;
using Ibge.Domain.Entities;

namespace Ibge.Domain.Mapping
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>()
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