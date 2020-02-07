namespace ProjectFirmaModels.Models
{
    public partial class ProjectCustomAttributeGroupProjectType : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ProjectCustomAttributeGroupProjectTypeID: {ProjectCustomAttributeGroupProjectTypeID}, ProjectCustomAttributeGroupID: {ProjectCustomAttributeGroupID}, ProjectTypeID: {ProjectTypeID}";
        }
    }
}