namespace ProjectFirmaModels.Models
{
    public partial class DocumentLibraryDocumentCategory: IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"Document Library ID: {DocumentLibraryID} Document Category ID: {DocumentCategoryID}";
    }
}