namespace Translation.Domain.Models
{
    public class ServiceInfo
    {
        public string ExternalServiceName { get; set; }
        public string CacheType { get; set; }
        public long CacheSize { get; set; }
    }
}
