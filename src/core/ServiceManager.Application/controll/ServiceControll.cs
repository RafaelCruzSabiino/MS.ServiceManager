using AutoMapper;
using ServiceManager.Domain.dtos;
using ServiceManager.Domain.exceptions;
using ServiceManager.Interfaces.inbound;
using ServiceManager.Interfaces.outbound;

namespace ServiceManager.Application.controll
{
    public class ServiceControll : IServiceControll
    {
        private readonly IServiceResource _processResource;
        private readonly IMapper _mapper;

        public ServiceControll(IServiceResource processResource, IMapper mapper)
        {
            _processResource = processResource;
            _mapper = mapper;
        }

        public ServiceDto Get(string serviceName)
        {
            ServiceDto process = new();

            try
            {
                process = _mapper.Map<ServiceDto>(_processResource.Get(serviceName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return process;
        }

        public List<ServiceDto> GetAll()
        {
            List<ServiceDto> process = new();

            try
            {
                process = _mapper.Map<List<ServiceDto>>(_processResource.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return process;
        }
    }
}
