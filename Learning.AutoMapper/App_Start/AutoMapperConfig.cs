using AutoMapper;
using Learning.AutoMapper.Models;
using Learning.AutoMapper.Repository;

namespace Learning.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Person, PersonViewModel>()
                    .ForMember(dest => dest.ConfirmEmail,
                        source => source.MapFrom(x => x.Email));
            });
        }
    }
}