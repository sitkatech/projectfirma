using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectCustomAttributeUpdate : IAuditableEntity, IProjectCustomAttribute
    {
        public string GetAuditDescriptionString()
        {
            return
                $"Custom Attribute (type: {ProjectCustomAttributeTypeID})";
        }

        public void SetCustomAttributeValues(IEnumerable<IProjectCustomAttributeValue> value) =>
            ProjectCustomAttributeUpdateValues = (ICollection<ProjectCustomAttributeUpdateValue>) value;

        public IEnumerable<IProjectCustomAttributeValue> GetCustomAttributeValues() => ProjectCustomAttributeUpdateValues.OrderBy(x => x.AttributeValue);
    }
}
