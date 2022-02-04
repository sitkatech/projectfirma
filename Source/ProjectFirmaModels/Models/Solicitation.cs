namespace ProjectFirmaModels.Models
{
    public partial class Solicitation : IAuditableEntity
    {
        public string GetDisplayName()
        {
            return SolicitationName;
        }

        public string GetAuditDescriptionString()
        {
            return SolicitationName;
        }
    }
}