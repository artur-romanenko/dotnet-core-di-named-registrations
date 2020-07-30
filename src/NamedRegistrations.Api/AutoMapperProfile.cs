using AutoMapper;

namespace NamedRegistrations.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Car, Api.Models.Car>();
        }
    }
}
