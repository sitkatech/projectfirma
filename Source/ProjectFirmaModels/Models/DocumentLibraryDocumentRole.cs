namespace ProjectFirmaModels.Models
{
    public partial class DocumentLibraryDocumentRole : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"Document Library Document ID: {DocumentLibraryDocumentID}, Role ID: {RoleID}";
    }
}