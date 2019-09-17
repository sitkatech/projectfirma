namespace ProjectFirmaModels.Models
{
    public partial class ProjectCustomAttributeGroup : IAuditableEntity, IHaveASortOrder
    {
        public string GetAuditDescriptionString() => ProjectCustomAttributeGroupName;

        public string GetDisplayName() => ProjectCustomAttributeGroupName;
        public void SetSortOrder(int? value) =>  SortOrder = value;
        public int? GetSortOrder() => SortOrder;
        public int GetID() => ProjectCustomAttributeGroupID;
    }
}