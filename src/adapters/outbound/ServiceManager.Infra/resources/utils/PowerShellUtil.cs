using System.Collections.ObjectModel;
using System.Management.Automation;

namespace ServiceManager.Infra.resources.utils
{
    public abstract class PowerShellUtil<T>
    {
        private Collection<PSObject> GetExec(string script)
        {
            Collection<PSObject> results = new();

            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript(script);

                results = ps.Invoke();
            }

            return results;
        }

        protected T? GetExecSingleValue(string script)
        {
            PSObject? pSObject = GetExec(script).FirstOrDefault();

            if (pSObject is null) return default;

            return pSObject.MapperPSObjectToEntity<T>();
        }

        protected List<T> GetExecManyValues(string script)
        {
            List<T> listGeneric = new();

            foreach (PSObject pSObject in GetExec(script))
                listGeneric.Add(pSObject.MapperPSObjectToEntity<T>());

            return listGeneric;
        }
    }
}
