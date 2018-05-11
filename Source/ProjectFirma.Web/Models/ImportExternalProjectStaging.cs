namespace ProjectFirma.Web.Models
{
    public partial class ImportExternalProjectStaging : IAuditableEntity
    {
        public string AuditDescriptionString =>
            $"Import External Project Staging created by {CreatePerson?.FullNameFirstLast ?? "<Person not Found>"} on {CreateDate}";
    }
}
