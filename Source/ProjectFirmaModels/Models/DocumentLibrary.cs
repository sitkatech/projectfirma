namespace ProjectFirmaModels.Models
{
    public partial class DocumentLibrary : IAuditableEntity
    {
        public string GetAuditDescriptionString() => DocumentLibraryName;
    }
}