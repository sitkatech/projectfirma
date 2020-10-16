namespace ProjectFirmaModels.Models
{
    public partial class MatchmakerOrganizationPerformanceMeasure : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return
                $"MatchmakerOrganizationPerformanceMeasureID: {MatchmakerOrganizationPerformanceMeasureID}, OrganizationID: {OrganizationID}, PerformanceMeasureID: {PerformanceMeasureID}";
        }
    }
}