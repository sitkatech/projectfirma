namespace ProjectFirmaModels.Models
{
    public partial class FundingSourceCustomAttributeTypeRole : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"Delete Funding Source Custom Attribute Type {FundingSourceCustomAttributeTypeID} where Role ID: {FundingSourceCustomAttributeTypeRoleID}, and Role Permission Type: {FundingSourceCustomAttributeTypeRolePermissionTypeID}";
    }
}
