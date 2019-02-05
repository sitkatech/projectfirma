namespace ProjectFirmaModels.Models
{
    public partial class ProjectCustomAttributeUpdateValue : IAuditableEntity, IProjectCustomAttributeValue
    {
        public string GetAuditDescriptionString()
        {
            return $"Custom Attribute Value (ID: {ProjectCustomAttributeUpdateID}, value = \"{AttributeValue}\")";
        }

        public void SetIProjectCustomAttributeValueID(int value) => ProjectCustomAttributeUpdateValueID = value;

        public int GetIProjectCustomAttributeValueID() => ProjectCustomAttributeUpdateValueID;

        public void SetIProjectCustomAttributeID(int value) => ProjectCustomAttributeUpdateID = value;

        public int GetIProjectCustomAttributeID() => ProjectCustomAttributeUpdateID;

        public void SetIProjectCustomAttribute(IProjectCustomAttribute value) =>
            ProjectCustomAttributeUpdate = (ProjectCustomAttributeUpdate) value;

        public IProjectCustomAttribute GetIProjectCustomAttribute() => ProjectCustomAttributeUpdate;
    }
}
