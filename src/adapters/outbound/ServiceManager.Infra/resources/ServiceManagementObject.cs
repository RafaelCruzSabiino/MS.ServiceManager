using ServiceManager.Domain.entities;
using ServiceManager.Domain.exceptions;
using ServiceManager.Infra.resources.utils;
using ServiceManager.Interfaces.outbound;

namespace ServiceManager.Infra.resources
{
    public class ServiceManagementObject : PowerShellUtil<ServiceEntity>, IServiceResource
    {
        public ServiceEntity Get(string serviceName)
            => GetExecSingleValue($"Get-Service -Name '{serviceName}'") ?? new();

        public List<ServiceEntity> GetAll()
            => GetExecManyValues("Get-Service");   
    }
}
