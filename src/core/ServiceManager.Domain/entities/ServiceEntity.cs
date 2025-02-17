namespace ServiceManager.Domain.entities
{
    public class ServiceEntity
    {
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string StartType { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public string MachineName { get; set; } = string.Empty;
        public string DependentServices { get; set; } = string.Empty;
        public string BinaryPathName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
