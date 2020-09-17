namespace ProjectFirmaModels.Models
{
    public partial class MatchmakerOrganizationClassification : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return
                $"MatchmakerOrganizationClassificationID: {MatchmakerOrganizationClassificationID}, OrganizationID: {OrganizationID}, ClassificationID: {ClassificationID}";
        }
    }
}