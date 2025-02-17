using System.Management.Automation;

namespace ServiceManager.Infra.resources.utils
{
    public static class MapperPowerShellObjectUtils
    {
        public static T MapperPSObjectToEntity<T>(this PSObject pSObject)
        {
            var entity = Activator.CreateInstance(typeof(T));
            var type = entity?.GetType();
            var properties = type?.GetProperties();

            if (properties is not null)
            {
                foreach (var property in properties)
                {
                    try
                    {
                        if (pSObject.Properties[property.Name] is not null && pSObject.Properties[property.Name].Value is not null)
                            property.SetValue(entity, pSObject.Properties[property.Name].Value.ToString());
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            return (T)(entity ?? new());
        }
    }
}
