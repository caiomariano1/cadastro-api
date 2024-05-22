using AutoMapper;
using cadastro_api.DTOs;
using cadastro_api.Entities;

namespace cadastro_api.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile() 
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
