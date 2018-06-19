using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class ProjectCustomAttributeSimple
    {
        public class CustomAttributeSimple
        {
            public int CustomAttributeTypeID { get; set; }
            public IEnumerable<string> CustomAttributeValues { get; set; }

            public CustomAttributeSimple()
            {
            }

            public CustomAttributeSimple(ProjectCustomAttribute customAttribute)
            {
                CustomAttributeTypeID = customAttribute.ProjectCustomAttributeTypeID;
                CustomAttributeValues =
                    customAttribute.ProjectCustomAttributeValues.Select(x => x.AttributeValue).ToList();
            }
        }
    }
}
