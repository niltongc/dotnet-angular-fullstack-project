using AutoMapper;
using Extrato.API.Models.Domain;
using Extrato.API.Models.DTO;

namespace Extrato.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<AddLauchDTO, Extract>().ReverseMap();
        }
    }
}
