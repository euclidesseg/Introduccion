
using APIMantenimiento.Models.DTOs.Client;
using APIMantenimiento.Models.Entities;
using AutoMapper;

namespace APIMantenimiento.Models.Config
{
    public class MappingProfile : Profile
    {

        public MappingProfile() {
            CreateMap<TipoFalla, TipoFallaDTO>();
        }
    }
}
