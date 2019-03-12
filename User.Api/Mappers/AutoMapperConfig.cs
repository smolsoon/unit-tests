using AutoMapper;
using User.Api.DTO;
using User.Api.Model;

namespace User.Api.Mappers {

    public static class AutoMapperConfig {
        public static IMapper Initialize () => new MapperConfiguration (cfg => {
            cfg.CreateMap<Users, UserDTO> ();
            cfg.CreateMap<Users, UserDetailsDTO> ();
        }).CreateMapper ();
    }

}