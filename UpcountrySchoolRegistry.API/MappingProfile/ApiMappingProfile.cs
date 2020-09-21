using AutoMapper;
using UpcountrySchoolRegistry.API.DataContracts.Responses;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.API.MappingProfile
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<SchoolResponse, School>().ReverseMap();
        }
    }
}
