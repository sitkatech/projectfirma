namespace ProjectFirmaModels.Models
{
    public partial class DocumentCategory: IAuditableEntity
    {
        public string GetAuditDescriptionString() => DocumentCategoryName;
    }
}