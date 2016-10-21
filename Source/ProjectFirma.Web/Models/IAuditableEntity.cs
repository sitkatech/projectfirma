namespace ProjectFirma.Web.Models
{
    public interface IAuditableEntity
    {
        string AuditDescriptionString { get; }
    }
}