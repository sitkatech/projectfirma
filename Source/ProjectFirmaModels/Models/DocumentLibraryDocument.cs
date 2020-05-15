namespace ProjectFirmaModels.Models
{
    public partial class DocumentLibraryDocument : IAuditableEntity, IHaveASortOrder
    {
        public string GetAuditDescriptionString() => $"Document Library ID: {DocumentLibraryID}, Document Title: {DocumentTitle}";

        public string GetDisplayName() => DocumentTitle;

        public int GetID() => DocumentLibraryDocumentID;

        public int? GetSortOrder() => SortOrder;

        public void SetSortOrder(int? value) => SortOrder = value;
    }
}