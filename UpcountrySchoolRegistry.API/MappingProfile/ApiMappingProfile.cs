using AutoMapper;
using UpcountrySchoolRegistry.API.DataContracts.Requests;
using UpcountrySchoolRegistry.API.DataContracts.Responses;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.API.MappingProfile
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<School, SchoolResponse>();
            CreateMap<SchoolCreateRequest, School>();
            CreateMap<SchoolUpdateRequest, School>();
        }
    }
}

