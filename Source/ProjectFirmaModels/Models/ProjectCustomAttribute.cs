using System.Collections.Generic;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectCustomAttribute : IAuditableEntity, IProjectCustomAttribute
    {
        public string GetAuditDescriptionString()
        {
            return $"Custom Attribute (type: {ProjectCustomAttributeTypeID}, Project: {ProjectID})";
        }

        public void SetCustomAttributeValues(IEnumerable<IProjectCustomAttributeValue> value) => ProjectCustomAttributeValues = (ICollection<ProjectCustomAttributeValue>) value;

        public IEnumerable<IProjectCustomAttributeValue> GetCustomAttributeValues() => ProjectCustomAttributeValues;
    }
}
