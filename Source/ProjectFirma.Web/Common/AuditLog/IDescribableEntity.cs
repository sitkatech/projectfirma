namespace ProjectFirma.Web.Common.AuditLog
{
    public interface IDescribableEntity
    {
        // Override this method to provide a description of the entity for audit purposes
        string Describe();
    }
}
