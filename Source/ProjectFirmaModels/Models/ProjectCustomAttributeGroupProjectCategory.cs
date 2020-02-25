namespace ProjectFirmaModels.Models
{
    public partial class ProjectCustomAttributeGroupProjectCategory : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ProjectCustomAttributeGroupProjectCategoryID: {ProjectCustomAttributeGroupProjectCategoryID}, ProjectCustomAttributeGroupID: {ProjectCustomAttributeGroupID}, ProjectCategoryID: {ProjectCategoryID}";
        }
    }
}