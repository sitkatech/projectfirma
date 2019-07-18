namespace ProjectFirmaModels.Models
{
    public partial class ProjectCustomAttributeValue : IAuditableEntity, IProjectCustomAttributeValue
    {
        public string GetAuditDescriptionString()
        {
            return $"Project Custom Attribute Value (ID: {ProjectCustomAttributeID}, value = \"{AttributeValue}\")";
        }

        public void SetIProjectCustomAttributeValueID(int value) => ProjectCustomAttributeValueID = value;

        public int GetIProjectCustomAttributeValueID() => ProjectCustomAttributeValueID;

        public void SetIProjectCustomAttributeID(int value) => ProjectCustomAttributeID = value;

        public int GetIProjectCustomAttributeID() => ProjectCustomAttributeID;

        public void SetIProjectCustomAttribute(IProjectCustomAttribute value) =>
            ProjectCustomAttribute = (ProjectCustomAttribute) value;

        public IProjectCustomAttribute GetIProjectCustomAttribute() => ProjectCustomAttribute;
    }
}
