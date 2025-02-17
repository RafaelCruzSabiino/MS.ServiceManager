using ServiceManager.Domain.entities;

namespace ServiceManager.Interfaces.outbound
{
    public interface IServiceResource
    {
        ServiceEntity Get(string serviceName);
        List<ServiceEntity> GetAll();
    }
}
