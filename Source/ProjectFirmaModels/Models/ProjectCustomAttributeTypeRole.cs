

namespace ProjectFirmaModels.Models
{
    public partial class ProjectCustomAttributeTypeRole : IAuditableEntity {
        public string GetAuditDescriptionString() => $"Delete Custom Attribute Type {ProjectCustomAttributeTypeID} where Role ID: {ProjectCustomAttributeTypeRoleID}, and Role Permission Type: {ProjectCustomAttributeTypeRolePermissionTypeID}";
    }
}

