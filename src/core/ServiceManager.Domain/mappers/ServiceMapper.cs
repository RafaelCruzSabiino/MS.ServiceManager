using AutoMapper;
using ServiceManager.Domain.dtos;
using ServiceManager.Domain.entities;

namespace ServiceManager.Domain.mappers
{
    internal class ServiceMapper : Profile
    {
        public ServiceMapper()
            => CreateMap<ServiceEntity, ServiceDto>().ReverseMap();
    }
}
