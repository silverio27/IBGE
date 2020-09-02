using System;
using AutoMapper;
using Ibge.Domain.RegionIbgeContext.Mapping.Profiles;

namespace Ibge.Domain.RegionIbgeContext.Mapping
{
    public class AutoMapperConfiguration
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RegionProfile());
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}