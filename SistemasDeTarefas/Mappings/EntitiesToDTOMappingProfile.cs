using AutoMapper;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Models.DTOs;

namespace SistemasDeTarefas.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<UsuarioModel, UsuarioDTO>().ReverseMap();
            CreateMap<TarefaModel, TarefaDTO>().ReverseMap();
        }
    }
}
