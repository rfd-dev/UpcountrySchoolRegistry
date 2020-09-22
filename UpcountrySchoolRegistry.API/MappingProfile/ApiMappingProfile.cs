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
            CreateMap<SchoolRequest, School>();            

            CreateMap<ClassRequest, Class>();//.ForPath(dest => dest.School.ID, opt => opt.MapFrom(src => src.SchoolID));
            CreateMap<Class, ClassResponse>().ForMember(dest => dest.SchoolID, opt => opt.MapFrom(src => src.School.ID));
        }
    }
}

