namespace ProjectFirmaModels.Models
{
    public partial class MatchMakerAreaOfInterestLocation : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"MatchMakerAreaOfInterestLocationID: {this.MatchMakerAreaOfInterestLocationID} - OrgID; {this.OrganizationID} - {this.TenantID}";
        }
    }
}