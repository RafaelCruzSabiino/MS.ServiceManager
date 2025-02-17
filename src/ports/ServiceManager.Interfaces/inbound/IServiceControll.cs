using ServiceManager.Domain.dtos;

namespace ServiceManager.Interfaces.inbound
{
    public interface IServiceControll
    {
        ServiceDto Get(string serviceName);
        List<ServiceDto> GetAll();
    }
}
