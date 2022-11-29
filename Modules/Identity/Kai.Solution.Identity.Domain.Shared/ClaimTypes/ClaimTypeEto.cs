using System;

namespace Kai.Solution.Identity
{
    [Serializable]
    public class ClaimTypeEto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Required { get; set; }

        public bool IsStatic { get; set; }

        public string Regex { get; set; }

        public string RegexDescription { get; set; }

        public string Description { get; set; }

        public ClaimValueType ValueType { get; set; }
    }
}
