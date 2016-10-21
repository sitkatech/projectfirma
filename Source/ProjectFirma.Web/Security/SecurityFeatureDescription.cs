using System;

namespace ProjectFirma.Web.Security
{
    public class SecurityFeatureDescription : Attribute
    {
        public string Name;
        public SecurityFeatureDescription(string name)
        {
            Name = name;
        }
    }
}