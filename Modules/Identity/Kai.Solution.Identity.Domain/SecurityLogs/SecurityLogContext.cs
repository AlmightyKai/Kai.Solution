using System.Collections.Generic;

namespace Kai.Solution.Identity
{
    public class SecurityLogContext
    {
        public string Identity { get; set; }

        public string Action { get; set; }

        public string UserName { get; set; }

        public string ClientId { get; set; }

        public Dictionary<string, object> ExtraProperties { get; }

        public SecurityLogContext()
        {
            ExtraProperties = new Dictionary<string, object>();
        }

        public virtual SecurityLogContext WithProperty(string key, object value)
        {
            ExtraProperties[key] = value;
            return this;
        }

    }
}
